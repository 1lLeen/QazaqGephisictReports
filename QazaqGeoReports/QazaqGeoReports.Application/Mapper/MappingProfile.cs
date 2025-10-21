using AutoMapper;
using QazaqGeoReports.Application.DTOs;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Mapper;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Report, ReportDto>().ReverseMap();
    }
}
