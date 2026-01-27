namespace QazaqGeoReports.Domain.Entities.Missions;

public class MissionDriverAssignment : BaseEntity
{
    public int MissionId { get; set; }
    public Mission Mission { get; set; } = default!;

    public string DriverId { get; set; } = default!;
    public User Driver { get; set; } = default!;

    public int CarId { get; set; }
    public Car Car { get; set; } = default!;
}