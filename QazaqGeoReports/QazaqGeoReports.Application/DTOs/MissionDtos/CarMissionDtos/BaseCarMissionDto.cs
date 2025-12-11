using QazaqGeoReports.Application.Interfaces.Dtos;
using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Domain.Entities.Missions;

namespace QazaqGeoReports.Application.DTOs.MissionDtos.CarMissionDtos;

public class BaseCarMissionDto : IBase
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public Car? Car { get; set; }

    public int MissionId { get; set; }
    public Mission? Mission { get; set; }

    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ReleasedAt { get; set; }
}
