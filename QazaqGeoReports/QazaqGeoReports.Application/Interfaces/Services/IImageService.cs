using QazaqGeoReports.Application.DTOs.ImageDtos;

namespace QazaqGeoReports.Application.Interfaces.Services;

public interface IImageService : IAbstractService<BaseImageDto, CreateImageDto, UpdateImageDto>
{
    Task<List<BaseImageDto>> GetImagesByReportIdAsync(int id, CancellationToken ct = default);
    Task DeleteAllImagesByReportIdAsync(int reportId, CancellationToken ct = default);
    string GetDataUrl(BaseImageDto img);
    string GuessMime(byte[] bytes);
}
