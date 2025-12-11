using QazaqGeoReports.Application.Interfaces.Dtos;
using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Domain.Entities.Missions;

namespace QazaqGeoReports.Application.DTOs.MissionDtos.EquipmentMissionDtos;

public class BaseEquipmentMissionDto : IBase
{
    public int Id { get; set; }
    public int MissionId { get; set; }
    public Mission? Mission { get; set; }

    public int EquipmentId { get; set; }
    public Equipment? Equipment { get; set; }
}
