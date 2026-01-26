using QazaqGeoReports.Application.DTOs.CarDtos;
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
    public ? Location { get; set; }
    public List<BaseUserDto?>? Employees { get; set; }
    public List<BaseCarDto?>? Cars { get; set; }
}
