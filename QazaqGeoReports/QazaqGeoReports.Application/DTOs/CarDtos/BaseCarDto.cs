using QazaqGeoReports.Application.Interfaces.Dtos;
using QazaqGeoReports.Domain.Common;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.DTOs.CarDtos;

public class BaseCarDto : IBase
{
    public int Id { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string LicensePlate { get; set; }
    public int Year { get; set; }

    public CarStatus Status { get; set; }          // Active, Repair, Broken, Reserved
    public int Mileage { get; set; }

    public string? DriverId { get; set; }
    public User? Driver { get; set; }

    public List<Mission> Missions { get; set; } = new();
    public List<Image> Images { get; set; } = new();
}
