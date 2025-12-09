using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QazaqGeoReports.Domain.Entities.Images;

namespace QazaqGeoReports.Infrastructure.Configurations.ImageConfiguration;

public class ImageEquipmentConfiguration : BaseConfiguration<ImageEquipment>
{
    public void Configure(EntityTypeBuilder<ImageEquipment> builder)
    {
        builder.ToTable("ImageEquipments");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Data).IsRequired();

        builder.HasOne(x => x.Equipment)
            .WithMany(e => e.Images)
            .HasForeignKey(x => x.EquipemntId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
