using QazaqGeoReports.Application.Interfaces.Dtos;

namespace QazaqGeoReports.Application.DTOs.PositionDtos;

public class UpdatedPositionDto : BasePositionDto, IUpdate
{
    public DateTime UpdatedTime { get; set; }
}
