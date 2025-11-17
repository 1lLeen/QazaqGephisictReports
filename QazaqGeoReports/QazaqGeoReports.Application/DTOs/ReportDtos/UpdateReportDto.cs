using System.ComponentModel.DataAnnotations;

namespace QazaqGeoReports.Application.DTOs.ReportDtos;

public class UpdateReportDto
{
    [Required(ErrorMessage = "Заголовок обязателен")]
    [StringLength(200, ErrorMessage = "Максимум 200 символов")]
    public string? Title { get; set; }

    public string? Content { get; set; }
    public string? Comments { get; set; }
    [Range(0, double.MaxValue, ErrorMessage = "Не может быть меньше 0")]
    public double? DistanceKM { get; set; }
    [Range(0, double.MaxValue, ErrorMessage = "Не может быть меньше 0")]
    public double? FuelUsedLiters { get; set; }
    public string? RouteDescription { get; set; }
    public string? UsersMovement { get; set; }
    public string? EquipmentsMovement { get; set; }
    public string? CreatedByUserId { get; set; }

    public DateTime? DepartureTime { get; set; }
    public DateTime? ArrivalTime { get; set; }

}
