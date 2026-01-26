using Microsoft.AspNetCore.Identity;
using QazaqGeoReports.Application.Interfaces.Dtos; 

namespace QazaqGeoReports.Application.DTOs.PositionDtos.PositionRoleDtos;

public class BasePositionRoleDto : IBase
{
    public int? PositionId { get; set; }
    public BasePositionDto? Position { get; set; } = default!;
    public string RoleId { get; set; } = default!;
    public IdentityRole Role { get; set; }
}
