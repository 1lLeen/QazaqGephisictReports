using QazaqGeoReports.Application.DTOs.GalleryDtos;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Interfaces.Repositories;

public interface IImageRepository : IAbstractRepository<Image>
{
    Task<List<Image>?> GetImagesByReportIdAsync(int reportId);
    Task<int> CountAsync(GalleryFilter normalized, CancellationToken ct);
    Task<IReadOnlyList<GalleryImageDto>> GetLatestAsync(int take, CancellationToken ct);
    Task<IReadOnlyList<GalleryImageDto>> QueryAsync(int take, GalleryFilter normalized, CancellationToken ct);
    Task DeleteAllImagesByReportIdAsync(int reportId, CancellationToken ct);
}
