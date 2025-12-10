using QazaqGeoReports.Application.Interfaces.Dtos;
using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Domain.Entities.Images;

namespace QazaqGeoReports.Application.DTOs.ReportDtos;

public class BaseReportDto : IBase
{
    public int Id { get; set; }
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
    public string ReportStatus { get; set; }
    public List<ImageReport> Images { get; set; } = new();
    public DateTime? DepartureTime { get; set; }
    public DateTime? ArrivalTime { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}
