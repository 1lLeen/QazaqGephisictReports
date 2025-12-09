using QazaqGeoReports.Application.Interfaces.Repositories.ImagesRepositories;
using QazaqGeoReports.Domain.Entities.Images;

namespace QazaqGeoReports.Infrastructure.Repositories.ImagesRepositories;

public class ImageReportRepository : AbstractRepository<ImageReport>,
    IImageReportRepository
{
    public ImageReportRepository(QazaqGeoReportContext context) : base(context)
    {
    }
}
