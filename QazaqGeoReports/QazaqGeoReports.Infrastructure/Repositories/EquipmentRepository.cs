using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Domain.Interfaces.Repositories;

namespace QazaqGeoReports.Infrastructure.Repositories;

public class EquipmentRepository : AbstractRepository<Equipment>, IEquipmentRepository
{
    public EquipmentRepository(QazaqGeoReportContext context) : base(context)
    {
    }
}
