using AutoMapper;
using QazaqGeoReports.Application.DTOs.PositionDtos;
using QazaqGeoReports.Application.DTOs.PositionDtos.PositionRoleDtos;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Mapper;

public class PositionMapperProfile : Profile
{
    public PositionMapperProfile()
    {
        CreateMap<BasePositionDto, Position>().ReverseMap();
        CreateMap<CreatePositionDto, Position>().ReverseMap();
        CreateMap<UpdatedPositionDto, Position>().ReverseMap();

        CreateMap<BasePositionRoleDto, PositionRole>().ReverseMap();
        CreateMap<CreatePositionRoleDto, PositionRole>().ReverseMap();
        CreateMap<UpdatePositionRoleDto, PositionRole>().ReverseMap();
    }
}
