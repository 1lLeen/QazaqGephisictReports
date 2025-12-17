using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Infrastructure.Repositories;

public class CarRepository : AbstractRepository<Car>,
    ICarRepository
{
    public CarRepository(QazaqGeoReportContext context) : base(context)
    {
    }
}
