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
    public User? Supervisor { get; set; }

    public List<User>? Workers { get; set; }
    public List<TaskItem>? Tasks { get; set; } = new();
    public List<Report>? Reports { get; set; } = new();
    public List<Equipment>? Equipments { get; set; } = new();
    public List<Car>? Cars { get; set; } = new();
}
