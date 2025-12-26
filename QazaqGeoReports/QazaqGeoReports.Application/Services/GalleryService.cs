using QazaqGeoReports.Application.DTOs.GalleryDtos;
using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Application.Interfaces.Services;

namespace QazaqGeoReports.Application.Services;

public class GalleryService : IGalleryService
{
    private readonly IImageRepository _repo;

    public GalleryService(IImageRepository repo)
    {
        _repo = repo;
    }
    public Task<IReadOnlyList<GalleryImageDto>> GetLatestAsync(int take = 24, CancellationToken ct = default)
     => _repo.GetLatestAsync(take, ct);
    public async Task<PagedResult<GalleryImageDto>> GetAsync(int take, GalleryFilter filter, CancellationToken ct = default)
    {
        var normalized = Normalize(filter);

        var totalTask = _repo.CountAsync(normalized, ct);
        var itemsTask = _repo.QueryAsync(take, normalized, ct);

        await Task.WhenAll(totalTask, itemsTask);

        return new PagedResult<GalleryImageDto>
        {
            Items = itemsTask.Result,
            Page = normalized.Page,
            PageSize = normalized.PageSize,
            TotalCount = totalTask.Result
        };
    }

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
