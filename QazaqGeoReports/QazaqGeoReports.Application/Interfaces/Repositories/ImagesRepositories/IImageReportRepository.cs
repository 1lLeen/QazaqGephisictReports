using QazaqGeoReports.Application.DTOs.GalleryDtos;
using QazaqGeoReports.Domain.Entities.Images;

namespace QazaqGeoReports.Application.Interfaces.Repositories.ImagesRepositories;

public interface IImageReportRepository : IImageAbstractRepository<ImageReport>
{
    Task DeleteAllImagesByReportIdAsync(int reportId);
    Task<IReadOnlyList<GalleryImageDto>> QueryAsync(GalleryFilter filter, CancellationToken ct);
    Task<int> CountAsync(GalleryFilter filter, CancellationToken ct);
}
