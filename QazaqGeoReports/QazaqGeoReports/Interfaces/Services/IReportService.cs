using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Domain.Interfaces.Services;
public interface IReportService : IAbstractService<Report>
{
    Task<List<Report>> GetReportsByUserAsync(string userId);
    Task<User> GetUserByReportIdAsync(int reportId);
}
