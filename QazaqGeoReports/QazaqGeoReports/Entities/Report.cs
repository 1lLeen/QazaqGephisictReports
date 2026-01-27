using QazaqGeoReports.Domain.Common;
using QazaqGeoReports.Domain.Entities.Missions;

namespace QazaqGeoReports.Domain.Entities;
public class Report : BaseEntity
{
    public int? MissionId { get; set; }     // nullable: бывают отчёты без миссии
    public Mission? Mission { get; set; }

    public string? CreatedByUserId { get; set; }
    public User? CreatedByUser { get; set; }

    public string? Content { get; set; }
    public string? Title { get; set; }
    public string? Comments { get; set; }

    public double? DistanceKM { get; set; }
    public double? FuelUsedLiters { get; set; }

    public string? RouteDescription { get; set; }

    public string? UsersMovement { get; set; }
    public string? EquipmentsMovement { get; set; }

    public string? ReportStatus { get; set; } // лучше enum
    public ReportType ReportType { get; set; }

    public List<Image> Images { get; set; } = new();

    public DateTime? DepartureTime { get; set; }
    public DateTime? ArrivalTime { get; set; }
}
