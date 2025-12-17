using AutoMapper;
using QazaqGeoReports.Application.DTOs.MissionDtos.CarMissionDtos;
using QazaqGeoReports.Application.Interfaces.Repositories.MissionsRepositories;
using QazaqGeoReports.Application.Interfaces.Services.MissionsRepositories;
using QazaqGeoReports.Domain.Entities.Missions;

namespace QazaqGeoReports.Application.Services.MissionsServices;

public class CarMissionService : AbstractService<ICarMissionRepository, CarMission, CreateCarMissionDto, UpdateCarMissionDto, BaseCarMissionDto, ListCarMissionViewModel>,
    ICarMissionService
{
    public CarMissionService(ICarMissionRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
