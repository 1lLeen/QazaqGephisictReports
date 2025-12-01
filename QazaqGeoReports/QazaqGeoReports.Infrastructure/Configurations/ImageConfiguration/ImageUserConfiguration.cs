using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QazaqGeoReports.Domain.Entities.Images;

namespace QazaqGeoReports.Infrastructure.Configurations.ImageConfiguration;

public class ImageUserConfiguration : BaseConfiguration<ImageUser>
{
    public void Configure(EntityTypeBuilder<ImageUser> builder)
    {
        builder.ToTable("ImageUsers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Data).IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.Images)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
