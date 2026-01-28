using QazaqGeoReports.Domain.Common;
using QazaqGeoReports.Domain.Entities.Users;

namespace QazaqGeoReports.Domain.Entities;

public class Mission : BaseEntity
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public MissionStatus Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? SupervisorId { get; set; }
    public User? Supervisor { get; set; }
    public string? Workers { get; set; }
    public string? CreatedByUser { get; set; }
} 