using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Domain.Entities.Images;

namespace QazaqGeoReports.Infrastructure.Repositories;

public class ImageRepository : AbstractRepository<Image>,
    IImageRepository
{
    public ImageRepository(QazaqGeoReportContext context) : base(context)
    {
    }
}
