using Microsoft.EntityFrameworkCore;
using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Domain.Common;
using QazaqGeoReports.Domain.Entities.Users;

namespace QazaqGeoReports.Infrastructure.Repositories;

public class ReportRepository : AbstractRepository<Report>, IReportRepository
{
    public ReportRepository(QazaqGeoReportContext context) : base(context)
    {}

    public async Task<List<Report>> GetReportsByUserAsync(string userId)
    {
        return await _context.Reports
        .AsNoTracking()
        .Where(r => r.CreatedByUserId == userId)
        .Include(r => r.CreatedByUser)
        .OrderByDescending(r => r.CreatedTime)
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
    public async Task<int> CountTodayAsync()
    {
        var today = DateTime.UtcNow.Date;
        return await _context.Reports
            .AsNoTracking()
            .CountAsync(r => r.CreatedTime.Date == today);
    }
    public async Task<int> CountByStatusAsync(ReportStatus status)
    {
        return await _context.Reports
            .AsNoTracking()
            .CountAsync(r => r.ReportStatus == status.ToString());
    }
}
