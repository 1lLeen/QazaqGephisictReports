using AutoMapper;
using QazaqGeoReports.Application.DTOs.CarDtos;
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
}
