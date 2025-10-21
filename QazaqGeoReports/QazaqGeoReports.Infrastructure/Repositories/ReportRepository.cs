using Microsoft.EntityFrameworkCore;
using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Domain.Interfaces.Repositories;

namespace QazaqGeoReports.Infrastructure.Repositories;

public class ReportRepository : AbstractRepository<Report>, IReportRepository
{
    public ReportRepository(QazaqGeoReportContext context) : base(context)
    {
    }

    public async Task<List<Report>> GetReportsByUserAsync(string userId)
    {
        return await _context.Reports.Where(x => x.CreatedByUserId == userId).ToListAsync();
    }
}
