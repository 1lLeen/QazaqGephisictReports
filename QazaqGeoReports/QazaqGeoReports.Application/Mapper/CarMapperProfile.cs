using AutoMapper;
using QazaqGeoReports.Application.DTOs.CarDtos;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Mapper;

public class CarMapperProfile : Profile
{
    public CarMapperProfile()
    {
        CreateMap<BaseCarDto, Car>().ReverseMap();
        CreateMap<CreateCarDto, Car>().ReverseMap();
        CreateMap<UpdateCarDto, Car>().ReverseMap();
        CreateMap<ListCarViewModel, Car>().ReverseMap();
    }
}
