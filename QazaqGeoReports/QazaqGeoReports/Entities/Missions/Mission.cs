using QazaqGeoReports.Domain.Common;

namespace QazaqGeoReports.Domain.Entities.Missions;

public class Mission : BaseEntity
{
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
    public List<EquipmentMission>? Equipments { get; set; } = new();
    public List<CarMission>? Cars { get; set; } = new();

}