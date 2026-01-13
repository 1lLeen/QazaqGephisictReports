using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Interfaces.Repositories;

public interface IMissionRepository : IAbstractRepository<Mission>
{
    public Task<List<Mission>>GetMissionsByUserIdAsync(string userID); 
    public Task<int> CountActiveAsync();
    public Task<int> CountOverdueAsync();
}
