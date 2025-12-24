using Microsoft.EntityFrameworkCore;
using QazaqGeoReports.Application.DTOs.GalleryDtos;
using QazaqGeoReports.Application.Interfaces.Repositories.ImagesRepositories;
using QazaqGeoReports.Domain.Entities.Images;

namespace QazaqGeoReports.Infrastructure.Repositories.ImagesRepositories;

public class ImageReportRepository : AbstractRepository<ImageReport>,
    IImageReportRepository
{
    public ImageReportRepository(QazaqGeoReportContext context) : base(context)
    {
    }
     
    public async Task DeleteAllImagesByReportIdAsync(int reportId)
    {
        var entities = await _context.ImageReports
            .Include(x => x.ReportId).ToListAsync();
        _context.ImageReports.RemoveRange(entities);
        await _context.SaveChangesAsync();
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
                ReportId = x.ReportId,
                ReportTitle = x.Report != null ? x.Report.Title : null
            })
            .ToListAsync(ct);
    }
    public async Task<IReadOnlyList<GalleryImageDto>> GetLatestAsync(int take, CancellationToken ct)
    {
        return await _context.ImageReports
           .AsNoTracking()
           .Include(x => x.Report)
           .OrderByDescending(x => x.CreatedTime)  
           .Take(take)
           .Select(x => new GalleryImageDto
           {
               Id = x.Id,
               Data = x.Data, 
               CreatedTime = x.CreatedTime,
               ReportId = x.ReportId,
               ReportTitle = x.Report != null ? x.Report.Title : null
           })
           .ToListAsync(ct);
    }
    
    private IQueryable<ImageReport> BuildQuery(GalleryFilter filter)
    {
        var q = _context.ImageReports
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
