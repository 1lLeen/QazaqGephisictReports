using Microsoft.AspNetCore.Identity;

namespace QazaqGeoReports.Domain.Entities;

public class PositionRole : BaseEntity
{ 
    public int? PositionId { get; set; }
    public Position? Position { get; set; } = default!;
    public string RoleId { get; set; } = default!;
    public IdentityRole Role { get; set; }
}
