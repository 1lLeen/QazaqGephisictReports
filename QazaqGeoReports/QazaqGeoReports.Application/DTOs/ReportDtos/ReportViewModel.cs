using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.DTOs.ReportDtos;

public class ReportViewModel
{
    public BaseReportDto Report { get; set; } = default!;
    public string UserName { get; set; } = string.Empty;
}
