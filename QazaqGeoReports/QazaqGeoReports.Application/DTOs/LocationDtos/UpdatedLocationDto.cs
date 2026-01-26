using QazaqGeoReports.Application.Interfaces.Dtos;

namespace QazaqGeoReports.Application.DTOs.LocationDtos;

public class UpdatedLocationDto : BaseLocationDto, IUpdate
{
    public DateTime UpdatedTime { get; set; }
}
