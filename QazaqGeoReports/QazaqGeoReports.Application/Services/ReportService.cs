using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Domain.Interfaces.Repositories;
using QazaqGeoReports.Domain.Interfaces.Services;

namespace QazaqGeoReports.Application.Services;
public class ReportService : AbstractService<IReportRepository, Report>, IReportService
{
    public ReportService(IReportRepository repository) : base(repository)
    {
    }
}
