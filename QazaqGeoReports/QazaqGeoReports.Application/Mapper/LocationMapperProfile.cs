using AutoMapper;
using QazaqGeoReports.Application.DTOs.LocationDtos;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Mapper;

public class LocationMapperProfile : Profile
{
    public LocationMapperProfile()
    {
        CreateMap<BaseLocationDto, Location>().ReverseMap();
        CreateMap<CreateLocationDto, Location>().ReverseMap();
        CreateMap<UpdateLocationDto, Location>().ReverseMap();
    }
}
