using QazaqGeoReports.Application.DTOs.ImageDtos;
using QazaqGeoReports.Application.DTOs.LocationDtos;
using QazaqGeoReports.Application.DTOs.MissionDtos;
using QazaqGeoReports.Application.DTOs.UserDtos;
using QazaqGeoReports.Application.Interfaces.Dtos;
using QazaqGeoReports.Domain.Common;
using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Domain.Entities.Missions;

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
    public int? Year { get; set;  }
    public string? DriverId { get; set; }
    public BaseUserDto? Driver { get; set; }
    public int? MissionId { get; set; }
    public BaseMissionDto? Mission { get; set; }
    public int? CurrentLocationId { get; set; }
    public BaseLocationDto? CurrentLocation { get; set; }
    public List<BaseImageDto> Images { get; set; } = new();
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}
