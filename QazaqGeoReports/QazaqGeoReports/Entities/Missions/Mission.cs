using QazaqGeoReports.Domain.Common;
using QazaqGeoReports.Domain.Entities.Users;

namespace QazaqGeoReports.Domain.Entities.Missions;

public class Mission : BaseEntity
{
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public MissionStatus Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public string? SupervisorId { get; set; }
    public User? Supervisor { get; set; }
     
    public string? CreatedByUserId { get; set; } = default!;
    public User? CreatedByUser { get; set; } = default!;
     
    public List<MissionUser> MissionUsers { get; set; } = new();
}