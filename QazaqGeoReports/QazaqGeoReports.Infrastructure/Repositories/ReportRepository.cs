using Microsoft.EntityFrameworkCore;
using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Domain.Interfaces.Repositories;
using QazaqGeoReports.Domain.Interfaces.Services;

namespace QazaqGeoReports.Infrastructure.Repositories;

public class ReportRepository : AbstractRepository<Report>, IReportRepository
{
    protected private IUserService userService;
    public ReportRepository(QazaqGeoReportContext context, IUserService userSerivce) : base(context)
    {
        this.userService = userSerivce;
    }

    public async Task<List<Report>> GetReportsByUserAsync(string userId)
    {
        return await _context.Reports.Where(x => x.CreatedByUserId == userId).ToListAsync();
    }
    public async Task<User> GetUserByReportId(int reportId)
    {
        var report = await _context.Reports
            .Include(r => r.CreatedByUserId)
            .FirstOrDefaultAsync(r => r.Id == reportId);

        return await userService.GetUserByIdAsync(report.CreatedByUserId);
    }
}
