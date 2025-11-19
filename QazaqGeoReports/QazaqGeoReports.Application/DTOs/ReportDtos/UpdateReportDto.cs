using QazaqGeoReports.Application.Interfaces.Dtos;
using System.ComponentModel.DataAnnotations;

namespace QazaqGeoReports.Application.DTOs.ReportDtos;

public class UpdateReportDto : BaseReportDto, IUpdate
{
    [Required(ErrorMessage = "Заголовок обязателен")]
    [StringLength(200, ErrorMessage = "Максимум 200 символов")]
    public new string? Title { get; set; }

    public new string? Content { get; set; }
    public new string? Comments { get; set; }
    [Range(0, double.MaxValue, ErrorMessage = "Не может быть меньше 0")]
    public new double? DistanceKM { get; set; }
    [Range(0, double.MaxValue, ErrorMessage = "Не может быть меньше 0")]
    public new double? FuelUsedLiters { get; set; }
}
