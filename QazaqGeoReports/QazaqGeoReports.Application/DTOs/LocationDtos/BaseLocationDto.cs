using QazaqGeoReports.Application.Interfaces.Dtos;

namespace QazaqGeoReports.Application.DTOs.LocationDtos;

public class BaseLocationDto : IBase
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public double? Latitude { get; set; } // x (широта)
    public double? Longitude { get; set; } // y (долгота)
    public DateTime? Timestamp { get; set; }

    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}
