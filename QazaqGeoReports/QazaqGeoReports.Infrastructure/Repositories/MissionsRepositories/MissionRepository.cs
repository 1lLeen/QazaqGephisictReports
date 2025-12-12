using QazaqGeoReports.Application.Interfaces.Repositories.MissionsRepositories;
using QazaqGeoReports.Domain.Entities.Missions;

namespace QazaqGeoReports.Infrastructure.Repositories.MissionsRepositories;

public class MissionRepository : AbstractRepository<Mission>,
    IMissionRepository
{
    public MissionRepository(QazaqGeoReportContext context) : base(context)
    {
    }
}
