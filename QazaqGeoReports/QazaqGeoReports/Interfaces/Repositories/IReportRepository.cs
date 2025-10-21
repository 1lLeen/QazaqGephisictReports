using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Domain.Interfaces.Repositories;

public interface IReportRepository : IAbstractRepository<Report>
{
    Task<List<Report>> GetReportsByUserAsync(string userId);
}
