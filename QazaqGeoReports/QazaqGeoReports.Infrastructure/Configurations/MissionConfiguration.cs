using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QazaqGeoReports.Domain.Entities.Missions;

namespace QazaqGeoReports.Infrastructure.Configurations;

public class MissionConfiguration : BaseConfiguration<Mission>
{
    public override void Configure(EntityTypeBuilder<Mission> builder)
    {
        base.Configure(builder); 

        builder.HasOne(m => m.Supervisor) 
            .WithMany()
            .IsRequired(false)
            .HasForeignKey(m => m.SupervisorId)
            .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.SetNull);
        builder.HasOne(m => m.CreatedByUser)
            .WithMany()
            .IsRequired(false)
            .HasForeignKey(m => m.CreatedByUserId)
            .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.SetNull); 
    }
}
