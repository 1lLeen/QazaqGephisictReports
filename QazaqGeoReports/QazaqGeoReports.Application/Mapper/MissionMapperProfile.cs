using AutoMapper;
using QazaqGeoReports.Application.DTOs.MissionDtos;
using QazaqGeoReports.Domain.Entities.Missions;

namespace QazaqGeoReports.Application.Mapper;

public class MissionMapperProfile : Profile
{
    public MissionMapperProfile()
    {
        CreateMap<BaseMissionDto, Mission>().ReverseMap();
        CreateMap<CreateMissionDto, Mission>().ReverseMap();
        CreateMap<UpdateMissionDto, Mission>().ReverseMap();
        CreateMap<ListMissionViewModel, Mission>().ReverseMap();
        CreateMap<Mission, BaseMissionDto>()
        .ForMember(d => d.Workers,
            opt => opt.MapFrom(s => s.MissionUsers
            .Where(mu => mu.User != null)
            .Select(mu => mu.User!)));
    }
}
