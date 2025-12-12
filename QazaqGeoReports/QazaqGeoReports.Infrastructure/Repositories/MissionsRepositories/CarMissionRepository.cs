using QazaqGeoReports.Application.Interfaces.Repositories.MissionsRepositories;
using QazaqGeoReports.Domain.Entities.Missions;

namespace QazaqGeoReports.Infrastructure.Repositories.MissionsRepositories;

public class CarMissionRepository : AbstractRepository<CarMission>,
    ICarMissionRepository
{
    public CarMissionRepository(QazaqGeoReportContext context) : base(context)
    {
    }
}
