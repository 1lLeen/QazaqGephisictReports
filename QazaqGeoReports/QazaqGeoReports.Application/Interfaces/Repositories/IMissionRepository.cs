using QazaqGeoReports.Domain.Entities.Missions;

namespace QazaqGeoReports.Application.Interfaces.Repositories;

public interface IMissionRepository : IAbstractRepository<Mission>
{
    Task<List<Mission>> GetMissionsByUserIdAsync(string userId);
    Task<Mission?> GetByIdWithUsersAsync(int id);
    Task<int> CountActiveAsync();
    Task<int> CountOverdueAsync();
}
