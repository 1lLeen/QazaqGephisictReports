using QazaqGeoReports.Application.DTOs.CarDtos;

namespace QazaqGeoReports.Application.Interfaces.Services;

public interface ICarService : IAbstractService<BaseCarDto, CreateCarDto, UpdateCarDto>
{
    Task<IQueryable<BaseCarDto>> GetAllByFilterAsync(CarQueryDto filter);
}
