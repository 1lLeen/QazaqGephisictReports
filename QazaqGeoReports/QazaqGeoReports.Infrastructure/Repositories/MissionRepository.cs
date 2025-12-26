using Microsoft.EntityFrameworkCore;
using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Infrastructure.Repositories;

public class MissionRepository : AbstractRepository<Mission>,
    IMissionRepository
{
    public MissionRepository(QazaqGeoReportContext context) : base(context)
    {
    }
    public async Task<int> CountActiveAsync()
    {
        return await _context.Missions
            .AsNoTracking()
            .CountAsync(m => m.Status == Domain.Common.MissionStatus.Active);
    }
    public async Task<int> CountOverdueAsync()
    {
        var today = DateTime.UtcNow.Date;
        return await _context.Missions
            .AsNoTracking()
            .CountAsync(m => m.EndDate < today && m.Status != Domain.Common.MissionStatus.Completed);
    }
}
