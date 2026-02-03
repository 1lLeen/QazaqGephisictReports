using AutoMapper;
using QazaqGeoReports.Application.DTOs.MissionDtos;
using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Application.Interfaces.Services;
using QazaqGeoReports.Domain.Entities.Missions;

namespace QazaqGeoReports.Application.Services;

public class MissionService : AbstractService<IMissionRepository, Mission, CreateMissionDto, UpdateMissionDto, BaseMissionDto, ListMissionViewModel>,
    IMissionService
{
    public MissionService(IMissionRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
    public override async Task<BaseMissionDto> UpdateAsync(UpdateMissionDto dto, int id)
    {
        if (dto is null) throw new ArgumentNullException(nameof(dto));

        if (dto.Id == 0) dto.Id = id;
        if (dto.Id != id) throw new ArgumentException("Id в dto не совпадает с id в маршруте.");
         
        var mission = await _repository.GetByIdWithUsersAsync(id);
        if (mission is null) throw new InvalidOperationException("Миссия не найдена.");
         
        mission.Title = dto.Title;
        mission.Description = dto.Description;
        mission.Status = dto.Status;
        mission.StartDate = dto.StartDate;
        mission.EndDate = dto.EndDate;
        mission.SupervisorId = dto.SupervisorId;
         
        var incomingIds = (dto.WorkerIds ?? new List<string>())
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => x.Trim())
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);
         
        var existingIds = mission.MissionUsers
            .Where(mu => !string.IsNullOrWhiteSpace(mu.UserId))
            .Select(mu => mu.UserId!)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);
         
        var toRemove = mission.MissionUsers
            .Where(mu => mu.UserId != null && !incomingIds.Contains(mu.UserId))
            .ToList();

        foreach (var r in toRemove)
            mission.MissionUsers.Remove(r); 
         
        var toAdd = incomingIds.Except(existingIds);
        foreach (var userId in toAdd)
        {
            mission.MissionUsers.Add(new MissionUser
            {
                MissionId = mission.Id,    
                UserId = userId
            });
        }
         
        await _repository.UpdateAsync(mission);
         
        var full = await _repository.GetByIdAsync(id);
        return mapper.Map<BaseMissionDto>(full);
    }
    public override async Task<BaseMissionDto> CreateAsync(CreateMissionDto dto)
    {
        var mission = mapper.Map<Mission>(dto);

        mission.CreatedByUserId = dto.CreatedByUserId;

        var ids = (dto.WorkerIds ?? new List<string>())
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => x.Trim())
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();


        mission.MissionUsers = ids
            .Select(userId => new MissionUser
            {
                UserId = userId,
                Mission = mission
            })
            .ToList();

        var created = await _repository.CreateAsync(mission);
        return mapper.Map<BaseMissionDto>(created);
    }
    public async Task<List<BaseMissionDto>> GetMissionsByUserIdAsync(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
            return new();

        var missions = await _repository.GetMissionsByUserIdAsync(userId);
         
        missions ??= new List<Mission>();

        return mapper.Map<List<BaseMissionDto>>(missions);
    }
}