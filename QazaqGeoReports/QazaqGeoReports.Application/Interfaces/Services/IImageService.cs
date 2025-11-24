using QazaqGeoReports.Application.DTOs.Common;
using QazaqGeoReports.Application.DTOs.ImageDtos;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Interfaces.Services;
public interface IImageService : IAbstractService<BaseImageDto, CreateImageDto, UpdateImageDto>
{
    Task<List<BaseImageDto>> GetImagesByReportId(int reportId);
    Task<List<BaseImageDto>> GetImagesByEquipmentId(int equipmentId);
    Task DeleteImagesByReportId(int reportId);
    string GetDataUrl(BaseImageDto img);
    string GuessMime(byte[] bytes);
}
