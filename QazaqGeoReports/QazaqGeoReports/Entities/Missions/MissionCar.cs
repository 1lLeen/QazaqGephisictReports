namespace QazaqGeoReports.Domain.Entities.Missions;

public class MissionCar : BaseEntity
{
    public int MissionId { get; set; }
    public Mission Mission { get; set; } = default!;

    public int CarId { get; set; }
    public Car Car { get; set; } = default!;
}