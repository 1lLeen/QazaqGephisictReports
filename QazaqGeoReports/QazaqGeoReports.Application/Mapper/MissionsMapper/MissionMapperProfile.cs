using AutoMapper;
using QazaqGeoReports.Application.DTOs.MissionDtos;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Mapper.MissionsMapper;

public class MissionMapperProfile : Profile
{
    public MissionMapperProfile()
    {
        CreateMap<BaseMissionDto, Mission>().ReverseMap();
        CreateMap<CreateMissionDto, Mission>().ReverseMap();
        CreateMap<UpdateMissionDto, Mission>().ReverseMap();
        CreateMap<ListMissionViewModel, Mission>().ReverseMap();
    }
}
