using QazaqGeoReports.Domain.Entities.Users;

namespace QazaqGeoReports.Domain.Entities.Missions;

public class MissionUser : BaseEntity
{
    public int? MissionId { get; set; }
    public Mission? Mission { get; set; } = default!;

    public string? UserId { get; set; } = default!;
    public User? User { get; set; } = default!;

}
