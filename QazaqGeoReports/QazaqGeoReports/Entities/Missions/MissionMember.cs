using QazaqGeoReports.Domain.Common;

namespace QazaqGeoReports.Domain.Entities.Missions;

public class MissionMember : BaseEntity
{
    public int MissionId { get; set; }
    public Mission Mission { get; set; } = default!;

    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;
     
    public MissionStatus Status { get; set; } 
}