using QazaqGeoReports.Application.Interfaces.Repositories.ImagesRepositories;
using QazaqGeoReports.Domain.Entities.Images;

namespace QazaqGeoReports.Infrastructure.Repositories.ImagesRepositories;

public class ImageEquipmentRepository : AbstractRepository<ImageEquipment>,
    IImageEquipmentRepository
{
    public ImageEquipmentRepository(QazaqGeoReportContext context) : base(context)
    {
    }
}
