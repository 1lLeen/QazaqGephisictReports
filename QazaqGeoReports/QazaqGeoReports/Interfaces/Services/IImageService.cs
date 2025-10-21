using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Domain.Interfaces.Services;
public interface IImageService : IAbstractService<Image>
{
    Task<List<Image>> GetImagesByReportId(int reportId);
    Task<List<Image>> GetImagesByEquipmentId(int equipmentId);
}
