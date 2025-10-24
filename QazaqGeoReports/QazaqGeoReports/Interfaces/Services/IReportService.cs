using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Domain.Interfaces.Services;
public interface IReportService : IAbstractService<Report>
{
    Task<IEnumerable<Report>> GetReportsByUserAsync(string userId);
    Task<User> GetUserByReportIdAsync(int reportId);
}
