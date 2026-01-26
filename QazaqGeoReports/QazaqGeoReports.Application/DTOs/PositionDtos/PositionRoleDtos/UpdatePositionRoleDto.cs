using QazaqGeoReports.Application.Interfaces.Dtos;

namespace QazaqGeoReports.Application.DTOs.PositionDtos.PositionRoleDtos;

public class UpdatePositionRoleDto : BasePositionRoleDto, IUpdate
{
    public DateTime UpdatedTime { get; set; }
}
