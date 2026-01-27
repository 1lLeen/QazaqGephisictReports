using QazaqGeoReports.Application.DTOs.UserDtos;
using QazaqGeoReports.Application.Interfaces.Dtos;
using QazaqGeoReports.Domain.Common;
using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Domain.Entities.Missions;

namespace QazaqGeoReports.Application.DTOs.MissionDtos.MissionsMemberDtos;

public class BaseMissionMemberDto : IBase
{
    public int Id { get; set; }
    public int MissionId { get; set; }
    public BaseMissionDto Mission { get; set; } = default!;

    public string UserId { get; set; } = default!;
    public BaseUserDto User { get; set; } = default!;

    public MissionStatus Status { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}
