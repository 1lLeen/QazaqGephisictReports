using AutoMapper;
using QazaqGeoReports.Application.DTOs.LocationDtos;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Mapper;

public class LocationMapperProfile : Profile
{
    public LocationMapperProfile()
    {
        CreateMap<BaseLocationDto, Location>().ReverseMap();
        CreateMap<CreatedLocationDto, Location>().ReverseMap();
        CreateMap<UpdatedLocationDto, Location>().ReverseMap();
    }
}
