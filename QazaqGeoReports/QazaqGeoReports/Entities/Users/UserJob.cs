using QazaqGeoReports.Domain.Common;

namespace QazaqGeoReports.Domain.Entities.Users;

public class UserJob : BaseEntity
{
    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;

    public string? JobTitle { get; set; }
    public string? PersonnelNumber { get; set; }
    public string? Note { get; set; }
    public Roles Role { get; set; }
}
