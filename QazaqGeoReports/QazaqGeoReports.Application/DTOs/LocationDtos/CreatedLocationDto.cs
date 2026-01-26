using QazaqGeoReports.Application.Interfaces.Dtos;

namespace QazaqGeoReports.Application.DTOs.LocationDtos;

public class CreatedLocationDto : BaseLocationDto, ICreate
{
    public DateTime CreatedTime { get; set; }
}
