using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Domain.Interfaces.Dtos;

namespace QazaqGeoReports.Application.DTOs.ReportDtos;

public class ListReportViewModel : IListView
{
    public Report Report { get; set; } = default!;
    public string UserName { get; set; } = string.Empty;

}
