namespace QazaqGeoReports.Domain.Entities.Missions;

public class CarMission : BaseEntity
{
    public int CarId { get; set; }
    public Car? Car { get; set; }

    public int MissionId { get; set; }
    public Mission? Mission { get; set; }

    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ReleasedAt { get; set; }
}
