using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Domain.Interfaces.Repositories;
using QazaqGeoReports.Domain.Interfaces.Services;

namespace QazaqGeoReports.Application.Services;
public class EquipmentService : AbstractService<IEquipmentRepository, Equipment>, IEquipmentService
{
    public EquipmentService(IEquipmentRepository repository) : base(repository)
    {
    }
}
