using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QazaqGeoReports.Domain.Entities.Images;

namespace QazaqGeoReports.Infrastructure.Configurations.ImageConfiguration;

public class ImageReportConfiguration : BaseConfiguration<ImageReport>
{
    public void Configure(EntityTypeBuilder<ImageReport> builder)
    {
        builder.ToTable("ImageReports");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Data).IsRequired();

        builder.HasOne(x => x.Report)
            .WithMany(x => x.Images)
            .HasForeignKey(x => x.ReportId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}
