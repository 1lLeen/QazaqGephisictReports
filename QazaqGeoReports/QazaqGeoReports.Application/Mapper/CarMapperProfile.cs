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
        CreateMap<UpdateCarDto, Car>()
        .ForMember(d => d.Id, opt => opt.Ignore())
        .ForMember(d => d.Driver, opt => opt.Ignore())
        .ForMember(d => d.Images, opt => opt.Ignore());
        CreateMap<ListCarViewModel, Car>().ReverseMap();
    }
}
