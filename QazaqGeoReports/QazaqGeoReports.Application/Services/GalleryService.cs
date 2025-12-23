using QazaqGeoReports.Application.DTOs.GalleryDtos;
using QazaqGeoReports.Application.Interfaces.Repositories.ImagesRepositories;
using QazaqGeoReports.Application.Interfaces.Services;

namespace QazaqGeoReports.Application.Services;

public class GalleryService : IGalleryService
{
    private readonly IImageReportRepository _repo;

    public GalleryService(IImageReportRepository repo)
    {
        _repo = repo;
    }

    public Task<PagedResult<GalleryImageDto>> GetAsync(GalleryFilter filter, CancellationToken ct = default)
        => _repo.QueryAsync(Normalize(filter), ct);

    private static GalleryFilter Normalize(GalleryFilter f)
    {
        var page = f.Page <= 0 ? 1 : f.Page;
        var pageSize = f.PageSize is < 1 or > 200 ? 24 : f.PageSize;

        return new GalleryFilter
        {
            From = f.From,
            To = f.To,
            Search = f.Search,
            Page = page,
            PageSize = pageSize
        };
    }
}
