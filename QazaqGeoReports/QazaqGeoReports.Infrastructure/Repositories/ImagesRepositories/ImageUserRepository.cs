using QazaqGeoReports.Application.Interfaces.Repositories.ImagesRepositories;
using QazaqGeoReports.Domain.Entities.Images;

namespace QazaqGeoReports.Infrastructure.Repositories.ImagesRepositories;

public class ImageUserRepository : AbstractRepository<ImageUser>,
    IImageUserRepository
{
    public ImageUserRepository(QazaqGeoReportContext context) : base(context)
    {
    }
}
