using Microsoft.EntityFrameworkCore;
using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Application.Interfaces.Repositories;

namespace QazaqGeoReports.Infrastructure.Repositories;

public class ReportRepository : AbstractRepository<Report>, IReportRepository
{
    public ReportRepository(QazaqGeoReportContext context) : base(context)
    {}

    public async Task<List<Report>> GetReportsByUserAsync(string userId)
    {
        return await _context.Reports
            .AsNoTracking()
            .Include(x => x.CreatedByUser)
            .OrderBy(x => x.CreatedTime)
            .ToListAsync();
    }
    public async Task<User> GetUserByReportId(int reportId)
    {
        var report = await _context.Reports 
            .Include(r => r.CreatedByUser)
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == reportId);

        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == report.CreatedByUserId);
    }
}
