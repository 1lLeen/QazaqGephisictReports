using QazaqGeoReports.Domain.Entities.Missions;

namespace QazaqGeoReports.Application.Interfaces.Repositories.MissionsRepositories;

public interface IMissionRepository : IAbstractRepository<Mission>
{
    public Task<int> CountActiveAsync();
    public Task<int> CountOverdueAsync();
}
