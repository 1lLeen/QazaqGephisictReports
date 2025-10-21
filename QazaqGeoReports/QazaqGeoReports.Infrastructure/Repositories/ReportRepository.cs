using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Infrastructure.Repositories;

public class ReportRepository : AbstractRepository<Report>
{
    public ReportRepository(QazaqGeoReportContext context) : base(context)
    {
    }
}
