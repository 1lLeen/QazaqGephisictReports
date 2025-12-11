using QazaqGeoReports.Domain.Common;
using QazaqGeoReports.Domain.Entities.Images;
using QazaqGeoReports.Domain.Entities.Missions;

namespace QazaqGeoReports.Domain.Entities;

public class Car : BaseEntity
{
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string LicensePlate { get; set; }
    public int Year { get; set; }

    public CarStatus Status { get; set; }          // Active, Repair, Broken, Reserved
    public int Mileage { get; set; }

    public string? DriverId { get; set; }
    public User? Driver { get; set; }

    public List<CarMission> Missions { get; set; } = new();
    public List<ImageCar> Images { get; set; } = new();
}
}
