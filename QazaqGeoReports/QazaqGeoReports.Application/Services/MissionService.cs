using AutoMapper;
using QazaqGeoReports.Application.DTOs.MissionDtos;
using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Application.Interfaces.Services;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Services;

public class MissionService : AbstractService<IMissionRepository, Mission, CreateMissionDto, UpdateMissionDto, BaseMissionDto, ListMissionViewModel>,
    IMissionService
{
    public MissionService(IMissionRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<List<BaseMissionDto>> GetMissionsByUserIdAsync(string userId)
    {
        var missions = await _repository.GetMissionsByUserIdAsync(userId); 
        var mapped = mapper.Map<List<BaseMissionDto>>(missions);
        return mapped;
    }
}