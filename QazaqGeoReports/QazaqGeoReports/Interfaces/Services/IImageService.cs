using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Domain.Interfaces.Services;
public interface IImageService : IAbstractService<Image>
{
    Task<List<Image>> GetImagesByReportId(int reportId);
    Task<List<Image>> GetImagesByEquipmentId(int equipmentId);
    Task DeleteImagesByReportId(int reportId);
    string GetDataUrl(Image img);
    string GuessMime(byte[] bytes);
}
