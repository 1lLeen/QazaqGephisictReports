using QazaqGeoReports.Application.DTOs.GalleryDtos;

namespace QazaqGeoReports.Application.Interfaces.Services;

public interface IGalleryService
{
    Task<IReadOnlyList<GalleryImageDto>> GetLatestAsync(int take = 24, CancellationToken ct = default);
}
