using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Interfaces.Repositories;
public interface IImageRepository : IAbstractRepository<Image>
{
    Task<List<Image>> GetImagesByReportId(int reportId);
    Task<List<Image>> GetImagesByEquipmentId(int equipmentId);
}
