using QazaqGeoReports.Domain.Entities.Images;

namespace QazaqGeoReports.Application.Interfaces.Repositories;
public interface IImageRepository : IAbstractRepository<Image>
{
    Task<List<Image>> GetImagesByReportId(int reportId);
    Task<List<Image>> GetImagesByEquipmentId(int equipmentId);
}
