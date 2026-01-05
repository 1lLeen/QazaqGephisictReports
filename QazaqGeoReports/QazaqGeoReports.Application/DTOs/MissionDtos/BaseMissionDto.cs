using QazaqGeoReports.Application.DTOs.CarDtos;
using QazaqGeoReports.Application.DTOs.EquipmentDtos;
using QazaqGeoReports.Application.DTOs.ReportDtos;
using QazaqGeoReports.Application.DTOs.TaskItemDtos;
using QazaqGeoReports.Application.DTOs.UserDtos;
using QazaqGeoReports.Application.Interfaces.Dtos;
using QazaqGeoReports.Domain.Common;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.DTOs.MissionDtos;

public class BaseMissionDto : IBase
{
    public int Id { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public MissionStatus Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? SupervisorId { get; set; }
    public BaseUserDto? Supervisor { get; set; }

    public List<BaseUserDto>? Workers { get; set; }
    public List<BaseTaskItemDto>? Tasks { get; set; } = new();
    public List<BaseReportDto>? Reports { get; set; } = new();
    public List<BaseEquipmentDto>? Equipments { get; set; } = new();
    public List<BaseCarDto>? Cars { get; set; } = new();
}
