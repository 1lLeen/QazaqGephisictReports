using QazaqGeoReports.Application.DTOs.Common;
using QazaqGeoReports.Application.DTOs.ImageDtos;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Interfaces.Services;
public interface IImageService : IAbstractService<BaseImageDto, CreateImageDto, UpdateImageDto>
{
    Task<ResultDto<List<BaseImageDto>>> GetImagesByReportId(int reportId);
    Task<ResultDto<List<BaseImageDto>>> GetImagesByEquipmentId(int equipmentId);
    Task DeleteImagesByReportId(int reportId);
    ResultDto<string> GetDataUrl(Image img);
    ResultDto<string> GuessMime(byte[] bytes);
}
