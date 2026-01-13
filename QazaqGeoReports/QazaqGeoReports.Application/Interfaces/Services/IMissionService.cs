using QazaqGeoReports.Application.DTOs.MissionDtos;

namespace QazaqGeoReports.Application.Interfaces.Services;

public interface IMissionService : IAbstractService<BaseMissionDto, CreateMissionDto, UpdateMissionDto>
{
    public Task<List<BaseMissionDto>> GetMissionsByUserIdAsync(string userId);
}
