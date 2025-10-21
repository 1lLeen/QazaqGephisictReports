using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Domain.Interfaces.Repositories;

public interface IReportRepository : IAbstractRepository<Report>
{
    Task<IEnumerable<Report>> GetReportsByUserAsync(string userId);
}
