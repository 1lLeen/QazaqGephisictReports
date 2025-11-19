using QazaqGeoReports.Application.Interfaces.Dtos;

namespace QazaqGeoReports.Application.DTOs.ReportDtos;

public class ListReportViewModel : IListView
{
    public BaseReportDto Report { get; set; } = default!;
    public string Title { get; set; } = string.Empty;

}
