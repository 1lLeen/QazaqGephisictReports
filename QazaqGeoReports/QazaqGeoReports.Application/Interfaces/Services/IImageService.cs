using QazaqGeoReports.Application.DTOs.Common;
using QazaqGeoReports.Application.DTOs.ImageDtos;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Interfaces.Services;
public interface IImageService : IAbstractService<BaseImageUserDto, CreateImageDto, UpdateImageDto>
{
    Task<List<BaseImageUserDto>> GetImagesByReportId(int reportId);
    Task<List<BaseImageUserDto>> GetImagesByEquipmentId(int equipmentId);
    Task DeleteImagesByReportId(int reportId);
    string GetDataUrl(BaseImageUserDto img);
    string GuessMime(byte[] bytes);
}
