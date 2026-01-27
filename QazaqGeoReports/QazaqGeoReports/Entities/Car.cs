using QazaqGeoReports.Domain.Common;
using QazaqGeoReports.Domain.Entities.Missions;

namespace QazaqGeoReports.Domain.Entities;

public class Car : BaseEntity
{
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? Marka { get; set; }
    public string LicensePlate { get; set; }
    public int? Mileage { get; set; }
    public CarStatus? Status { get; set; }
    public bool? IsReady{ get;set; }
    public string FullNameDriver { get => Driver != null ? $"{Driver.FirstName} {Driver.LastName}" : string.Empty; }
    public string? DriverId { get; set; }
    public User? Driver { get; set; }
    public int? MissionId { get; set; }
    public Mission? Mission { get; set; }
    public int? CurrentLocationId { get; set; }
    public Location? CurrentLocation { get; set; }
    public List<Image> Images { get; set; } = new();
} 
