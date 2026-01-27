using QazaqGeoReports.Domain.Common;

namespace QazaqGeoReports.Domain.Entities.Missions;

public class Mission : BaseEntity
{
    public string? CreatedByUser { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public MissionStatus Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? SupervisorId { get; set; }
    public User? Supervisor { get; set; }
    public int? LocationId { get; set; }
    public Location? Location { get; set; }
    public List<MissionMember> Members { get; set; } = new();
    public List<MissionCar> Cars { get; set; } = new();
    public List<MissionDriverAssignment> DriverAssignments { get; set; } = new();
}