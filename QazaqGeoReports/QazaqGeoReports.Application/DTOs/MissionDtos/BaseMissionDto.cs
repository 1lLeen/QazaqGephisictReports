using QazaqGeoReports.Application.DTOs.CarDtos;
using QazaqGeoReports.Application.DTOs.LocationDtos;
using QazaqGeoReports.Application.DTOs.MissionDtos.MissionDriverAssignment;
using QazaqGeoReports.Application.DTOs.MissionDtos.MissionsCarDtos;
using QazaqGeoReports.Application.DTOs.MissionDtos.MissionsMemberDtos;
using QazaqGeoReports.Application.DTOs.UserDtos;
using QazaqGeoReports.Application.Interfaces.Dtos;
using QazaqGeoReports.Domain.Common; 

namespace QazaqGeoReports.Application.DTOs.MissionDtos;

public class BaseMissionDto : IBase
{
    public int Id { get; set; }
    public string? CreatedByUser { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public MissionStatus Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? SupervisorId { get; set; }
    public BaseUserDto? Supervisor { get; set; }
    public int? LocationId { get; set; }
    public BaseLocationDto? Location { get; set; }
    public List<BaseMissionMemberDto> Members { get; set; } = new();
    public List<BaseMissionCarDto> Cars { get; set; } = new();
    public List<BaseMissionDriverAssignmentDto> DriverAssignments { get; set; } = new();
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}
