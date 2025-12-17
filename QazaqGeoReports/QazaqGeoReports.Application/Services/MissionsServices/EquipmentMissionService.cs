using AutoMapper;
using QazaqGeoReports.Application.DTOs.MissionDtos.EquipmentMissionDtos;
using QazaqGeoReports.Application.Interfaces.Repositories.MissionsRepositories;
using QazaqGeoReports.Application.Interfaces.Services.MissionsRepositories;
using QazaqGeoReports.Domain.Entities.Missions;

namespace QazaqGeoReports.Application.Services.MissionsServices;

public class EquipmentMissionService : AbstractService<IEquipmentMissionRepository, EquipmentMission, CreateEquipmentMissionDto, UpdateEquipmentMissionDto, BaseEquipmentMissionDto, ListEquipmentMissionViewModel>,
    IEquipmentMissionService
{
    public EquipmentMissionService(IEquipmentMissionRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
