using AutoMapper;
using QazaqGeoReports.Application.DTOs.MissionDtos.EquipmentMissionDtos;
using QazaqGeoReports.Domain.Entities.Missions;

namespace QazaqGeoReports.Application.Mapper.MissionsMapper;

public class EquipmentMissionMapperProfile : Profile
{
    public EquipmentMissionMapperProfile()
    {
        CreateMap<BaseEquipmentMissionDto, EquipmentMission>().ReverseMap();
        CreateMap<CreateEquipmentMissionDto, EquipmentMission>().ReverseMap();
        CreateMap<UpdateEquipmentMissionDto, EquipmentMission>().ReverseMap();
        CreateMap<ListEquipmentMissionViewModel, EquipmentMission>().ReverseMap();
    }
}
