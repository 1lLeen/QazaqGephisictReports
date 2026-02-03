using Microsoft.EntityFrameworkCore; 
using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Domain.Common;
using QazaqGeoReports.Domain.Entities.Missions; 

namespace QazaqGeoReports.Infrastructure.Repositories;

public class MissionRepository : AbstractRepository<Mission>, IMissionRepository
{
    public MissionRepository(QazaqGeoReportContext context) : base(context) { }

    public async Task<List<Mission>> GetMissionsByUserIdAsync(string userId)
    {
        return await _context.Missions
            .AsNoTracking()
            .Include(m => m.Supervisor)
            .Include(m => m.CreatedByUser)
            .Include(m => m.MissionUsers)
            .Where(m =>
                m.CreatedByUserId == userId ||
                m.SupervisorId == userId ||
                m.MissionUsers.Any(mu => mu.UserId == userId))
            .OrderByDescending(m => m.StartDate ?? m.CreatedTime)
            .ToListAsync();
    }

    public override async Task<Mission?> GetByIdAsync(int id)
    {
        return await _context.Missions
            .AsNoTracking()
            .Include(m => m.Supervisor)
            .Include(m => m.CreatedByUser)
            .Include(m => m.MissionUsers).ThenInclude(mu => mu.User)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Mission?> GetByIdWithUsersAsync(int id)
    {
        return await _context.Missions
            .Include(m => m.MissionUsers)
            .FirstOrDefaultAsync(m => m.Id == id);
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
