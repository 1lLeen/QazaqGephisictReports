using QazaqGeoReports.Domain.Common;

namespace QazaqGeoReports.Domain.Entities;
public class Report : BaseEntity
{
    public int ImageId { get; set; }
    public string? CreatedByUserId { get; set; }
    public string? Content { get; set; }
    public string? Title { get; set; }
    public string? Comments { get; set; }
    public double? DistanceKM { get; set; }
    public double? FuelUsedLiters { get; set; }
    public string? RouteDescription { get; set; }
    public string? UsersMovement { get; set; }
    public string? EquipmentsMovement { get; set; }
    public DateTime? DepartureTime { get; set; }
    public DateTime? ArrivalTime { get; set; }

}
