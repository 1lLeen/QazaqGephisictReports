using AutoMapper;
using QazaqGeoReports.Application.DTOs.CarDtos;
using QazaqGeoReports.Application.DTOs.UserDtos;
using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Application.Interfaces.Services;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Services;

public class CarService : AbstractService<ICarRepository, Car, CreateCarDto, UpdateCarDto, BaseCarDto, ListCarViewModel>,
    ICarService
{
    public CarService(ICarRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<IQueryable<BaseCarDto>> GetAllByFilterAsync(CarQueryDto filter)
    {
        var q =  await _repository.GetAllAsync();

        if (filter.Status is not null)
            q = q.Where(x => x.Status == filter.Status.Value);

        if (!string.IsNullOrWhiteSpace(filter.Query))
        {
            var s = filter.Query.Trim().ToLower();

            q = q.Where(x =>
                (x.Brand ?? "").ToLower().Contains(s) ||
                (x.Model ?? "").ToLower().Contains(s) ||
                x.LicensePlate.ToLower().Contains(s) ||
                (x.Driver != null ? (x.Driver.UserName ?? "").ToLower().Contains(s) : false)
            );
        }
        q = filter.Sort switch
        {
            SortKey.BrandAsc => q.OrderBy(x => x.Brand).ThenBy(x => x.Model),
            SortKey.MileageDesc => q.OrderByDescending(x => x.Mileage),
            _ => q.OrderByDescending(x => x.UpdatedTime)
        };
        var query = q.Select(x => new BaseCarDto
        {
            Id = x.Id,
            CreatedTime = x.CreatedTime,
            UpdatedTime = x.UpdatedTime,
            Brand = x.Brand,
            Model = x.Model,
            LicensePlate = x.LicensePlate,
            DriverId = x.DriverId,
            Driver = mapper.Map<BaseUserDto?>(x.Driver),
            Images = x.Images
        });
        return query;
    }
}
