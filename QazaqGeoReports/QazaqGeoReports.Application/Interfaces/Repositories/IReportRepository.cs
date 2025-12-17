using QazaqGeoReports.Domain.Common;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Interfaces.Repositories;

public interface IReportRepository : IAbstractRepository<Report>
{
    Task<List<Report>> GetReportsByUserAsync(string userId);
    Task<User> GetUserByReportId(int reportId);
    Task<int> CountTodayAsync();
    Task<int> CountByStatusAsync(ReportStatus status);
}
