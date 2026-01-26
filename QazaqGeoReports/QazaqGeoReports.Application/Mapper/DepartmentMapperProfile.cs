using AutoMapper;
using QazaqGeoReports.Application.DTOs.DepartmentDtos;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Mapper;

public class DepartmentMapperProfile : Profile
{
    public DepartmentMapperProfile()
    {
        CreateMap<BaseDepartmentDto, Department>().ReverseMap();
        CreateMap<CreateDepartmentDto, Department>().ReverseMap();
        CreateMap<UpdateDepartmentDto, Department>().ReverseMap();
    }
}
