using QazaqGeoReports.Application.Interfaces.Dtos;

namespace QazaqGeoReports.Application.DTOs.PositionDtos;

public class CreatePositionDto : BasePositionDto, ICreate
{
    public DateTime CreatedTime { get; set; }
}
