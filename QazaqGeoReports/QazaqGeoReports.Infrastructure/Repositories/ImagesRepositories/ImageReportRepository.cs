using Microsoft.EntityFrameworkCore;
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
            .Where(x => x.ReportId == reportId).ToListAsync();
        _context.ImageReports.RemoveRange(entities);
        await _context.SaveChangesAsync();
    }
}
