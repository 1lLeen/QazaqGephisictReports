using QazaqGeoReports.Application.DTOs.GalleryDtos;
using QazaqGeoReports.Domain.Entities.Images;

namespace QazaqGeoReports.Application.Interfaces.Repositories.ImagesRepositories;

public interface IImageReportRepository : IImageAbstractRepository<ImageReport>
{
    Task DeleteAllImagesByReportIdAsync(int reportId); 
    Task<IReadOnlyList<GalleryImageDto>> GetLatestAsync(int take, CancellationToken ct);
    Task<IReadOnlyList<GalleryImageDto>> QueryAsync(int take, GalleryFilter filter, CancellationToken ct); 
    Task<int> CountAsync(GalleryFilter filter, CancellationToken ct);
}
