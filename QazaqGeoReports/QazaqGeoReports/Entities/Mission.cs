using QazaqGeoReports.Domain.Common; 

namespace QazaqGeoReports.Domain.Entities;

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
    public int? LocationId { get; set;  }
    public Location? Location { get; set; }
    public List<User?>? Employees { get; set; } 
    public List<Car?>? Cars { get; set; }
} 