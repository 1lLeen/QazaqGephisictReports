using QazaqGeoReports.Application.Interfaces.Dtos;

namespace QazaqGeoReports.Application.DTOs.PositionDtos.PositionRoleDtos;

public class CreatePositionRoleDto : BasePositionRoleDto, ICreate
{
    public DateTime CreatedTime { get; set; }
}
