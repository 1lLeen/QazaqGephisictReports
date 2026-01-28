using QazaqGeoReports.Domain.Entities.Users;

namespace QazaqGeoReports.Domain.Entities;

public class Location : BaseEntity
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public double? Latitude { get; set; } // x (широта)
    public double? Longitude { get; set; } // y (долгота)
    public DateTime? Timestamp { get; set; }
}
