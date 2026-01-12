using QazaqGeoReports.Application.DTOs.CarDtos;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Interfaces.Repositories;

public interface ICarRepository : IAbstractRepository<Car>
{
    Task<IQueryable<Car>> GetAllAsync();
}
