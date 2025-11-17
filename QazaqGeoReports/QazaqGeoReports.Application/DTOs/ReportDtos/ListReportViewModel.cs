using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.DTOs.ReportDtos;

public class ListReportViewModel
{
    public Report Report { get; set; } = default!;
    public string UserName { get; set; } = string.Empty;

}
