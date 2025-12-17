using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Interfaces.Repositories;
public interface IEquipmentRepository : IAbstractRepository<Equipment>
{
    public Task<int> CountByStatusAsync(Domain.Common.EquipmentStatus status);
}
