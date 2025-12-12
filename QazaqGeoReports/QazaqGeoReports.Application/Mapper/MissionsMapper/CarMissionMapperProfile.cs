using AutoMapper;
using QazaqGeoReports.Application.DTOs.MissionDtos.CarMissionDtos;
using QazaqGeoReports.Domain.Entities.Missions;

namespace QazaqGeoReports.Application.Mapper.MissionsMapper;

public class CarMissionMapperProfile : Profile
{
    public CarMissionMapperProfile()
    {
        CreateMap<BaseCarMissionDto, CarMission>().ReverseMap();
        CreateMap<CreateCarMissionDto, CarMission>().ReverseMap();
        CreateMap<UpdateCarMissionDto, CarMission>().ReverseMap();
        CreateMap<ListCarMissionViewModel, CarMission>().ReverseMap();
    }
}
