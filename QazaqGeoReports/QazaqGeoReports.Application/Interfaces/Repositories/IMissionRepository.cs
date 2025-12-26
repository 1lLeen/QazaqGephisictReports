using QazaqGeoReports.Domain.Entities.Missions;

namespace QazaqGeoReports.Application.Interfaces.Repositories;

public interface IMissionRepository : IAbstractRepository<Mission>
{
    public Task<int> CountActiveAsync();
    public Task<int> CountOverdueAsync();
}
