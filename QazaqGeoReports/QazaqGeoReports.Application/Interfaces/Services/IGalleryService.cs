using QazaqGeoReports.Application.DTOs.GalleryDtos;

namespace QazaqGeoReports.Application.Interfaces.Services;

public interface IGalleryService
{
    Task<PagedResult<GalleryImageDto>> GetAsync(GalleryFilter filter, CancellationToken ct = default);
}
