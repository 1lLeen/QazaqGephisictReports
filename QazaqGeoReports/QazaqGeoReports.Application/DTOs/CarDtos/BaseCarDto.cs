using QazaqGeoReports.Application.DTOs.UserDtos;
using QazaqGeoReports.Application.Interfaces.Dtos;
using QazaqGeoReports.Domain.Common;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.DTOs.CarDtos;

public class BaseCarDto : IBase
{
    public int Id { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? Marka { get; set; }
    public string LicensePlate { get; set; }
    public int? Mileage { get; set; }
    public CarStatus? Status { get; set; }
    public bool? IsReady { get; set; }
    public string FullNameDriver { get => Driver != null ? $"{Driver.FirstName} {Driver.LastName}" : string.Empty; }
    public string? DriverId { get; set; }
    public User? Driver { get; set; }
    public int? MissionId { get; set; }
    public Mission? Mission { get; set; }
    public int? CurrentLocationId { get; set; }
    public Location? CurrentLocation { get; set; }
    public List<Image> Images { get; set; } = new();
}
