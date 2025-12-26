using Microsoft.EntityFrameworkCore;
using QazaqGeoReports.Application.DTOs.GalleryDtos;
using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Infrastructure.Repositories;

public class ImageRepository : AbstractRepository<Image>,
    IImageRepository
{
    public ImageRepository(QazaqGeoReportContext context) : base(context)
    {
    }
    public async Task<List<Image>?> GetImagesByReportIdAsync(int reportId)
    {
        return await _context.Images
            .Where(x => x.ReportId == reportId)
            .ToListAsync();
    }
    public async Task DeleteAllImagesByReportIdAsync(int reportId, CancellationToken ct)
    {
        var images = await _context.Images
            .Where(x => x.ReportId == reportId)
            .ToListAsync(ct);
        _context.Images.RemoveRange(images);
        await _context.SaveChangesAsync(ct);
    }
    public async Task<IReadOnlyList<GalleryImageDto>> QueryAsync(int take, GalleryFilter filter, CancellationToken ct)
    {
        var q = BuildQuery(filter);

        q = q.OrderByDescending(x => x.CreatedTime).ThenByDescending(x => x.Id);

        var skip = (filter.Page - 1) * filter.PageSize;

        return await q
            .Skip(skip)
            .Take(filter.PageSize)
            .OrderByDescending(x => x.CreatedTime)
            .Take(take)
            .Select(x => new GalleryImageDto
            {
                Id = x.Id,
                Data = x.Data,
                CreatedTime = x.CreatedTime,
                ReportId = (int)x.ReportId,
                ReportTitle = x.Report != null ? x.Report.Title : null
            })
            .ToListAsync(ct);
    }
    public async Task<IReadOnlyList<GalleryImageDto>> GetLatestAsync(int take, CancellationToken ct)
    {
        return await _context.Images
           .AsNoTracking()
           .Include(x => x.Report)
           .OrderByDescending(x => x.CreatedTime)
           .Take(take)
           .Select(x => new GalleryImageDto
           {
               Id = x.Id,
               Data = x.Data,
               CreatedTime = x.CreatedTime,
               ReportId = (int)x.ReportId,
               ReportTitle = x.Report != null ? x.Report.Title : null
           })
           .ToListAsync(ct);
    }

    private IQueryable<Image> BuildQuery(GalleryFilter filter)
    {
        var q = _context.Images
            .AsNoTracking()
            .Include(x => x.Report)
            .AsQueryable();

        if (filter.From is not null)
            q = q.Where(x => x.CreatedTime >= filter.From.Value);

        if (filter.To is not null)
            q = q.Where(x => x.CreatedTime <= filter.To.Value);

        if (!string.IsNullOrWhiteSpace(filter.Search))
        {
            var s = filter.Search.Trim();
            q = q.Where(x =>
                (x.Report != null && x.Report.Title.Contains(s)));
        }

        return q;
    }
    public async Task<int> CountAsync(GalleryFilter filter, CancellationToken ct)
    {
        var q = BuildQuery(filter);

        return await q.CountAsync(ct);
    }
}
