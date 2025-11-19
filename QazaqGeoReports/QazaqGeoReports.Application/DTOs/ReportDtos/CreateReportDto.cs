using QazaqGeoReports.Application.Interfaces.Dtos;
using System.ComponentModel.DataAnnotations;

namespace QazaqGeoReports.Application.DTOs.ReportDtos;

public class CreateReportDto : BaseReportDto, ICreate
{
    [Required]
    public new string Title { get; set; } = string.Empty;

    [Range(0, 99999)]
    public new double? DistanceKM { get; set; }

    [Range(0, 99999)]
    public new double? FuelUsedLiters { get; set; }
    [DataType(DataType.Date)]
    public new DateTime? DepartureTime { get; set; }
    [DataType(DataType.Date)]
    public new DateTime? ArrivalTime { get; set; }
}
