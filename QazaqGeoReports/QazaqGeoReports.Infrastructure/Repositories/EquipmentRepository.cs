using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Infrastructure.Repositories;

public class EquipmentRepository : AbstractRepository<Equipment>
{
    public EquipmentRepository(QazaqGeoReportContext context) : base(context)
    {
    }
}
