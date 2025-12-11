namespace QazaqGeoReports.Domain.Entities.Missions;

public class EquipmentMission : BaseEntity
{
    public int MissionId { get; set; }
    public Mission? Mission { get; set; }

    public int EquipmentId { get; set; }
    public Equipment? Equipment { get; set; }
}
