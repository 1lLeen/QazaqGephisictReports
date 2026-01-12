using AutoMapper;
using Microsoft.EntityFrameworkCore; 
using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Infrastructure.Repositories;

public class CarRepository : AbstractRepository<Car>,
    ICarRepository
{ 
    public CarRepository(QazaqGeoReportContext context) : base(context)
    { 
    }
    public virtual async Task<IQueryable<Car>> GetAllAsync()
    {
        var q = _context.Cars
            .AsNoTracking()
            .Include(x => x.Driver)
            .Include(x => x.Images)
            .AsQueryable();

        return q;
    }
}
