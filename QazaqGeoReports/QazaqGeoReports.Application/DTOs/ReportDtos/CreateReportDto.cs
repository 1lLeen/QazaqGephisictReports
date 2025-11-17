using System.ComponentModel.DataAnnotations;

namespace QazaqGeoReports.Application.DTOs.ReportDtos;

public class CreateReportDto
{
    [Required]
    public string Title { get; set; } = string.Empty;

    public string? Content { get; set; }
    public string? Comments { get; set; }
    public string? RouteDescription { get; set; }
    public string? UsersMovement { get; set; }
    public string? EquipmentsMovement { get; set; }

    [Range(0, 99999)]
    public double? DistanceKM { get; set; }

    [Range(0, 99999)]
    public double? FuelUsedLiters { get; set; }
    [DataType(DataType.Date)]
    public DateTime? DepartureTime { get; set; }
    [DataType(DataType.Date)]
    public DateTime? ArrivalTime { get; set; }
}
