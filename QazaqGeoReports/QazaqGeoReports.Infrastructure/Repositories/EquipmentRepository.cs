using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace QazaqGeoReports.Infrastructure.Repositories;

public class EquipmentRepository : AbstractRepository<Equipment>, IEquipmentRepository
{
    public EquipmentRepository(QazaqGeoReportContext context) : base(context)
    {
    }
    public async Task<int> CountByStatusAsync(Domain.Common.EquipmentStatus status)
    {
        return await _context.Equipments
            .AsNoTracking()
            .CountAsync(e => e.Status == status.ToString());
    }
}
