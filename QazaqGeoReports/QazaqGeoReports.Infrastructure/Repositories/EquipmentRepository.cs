using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Application.Interfaces.Repositories;

namespace QazaqGeoReports.Infrastructure.Repositories;

public class EquipmentRepository : AbstractRepository<Equipment>, IEquipmentRepository
{
    public EquipmentRepository(QazaqGeoReportContext context) : base(context)
    {
    }
}
