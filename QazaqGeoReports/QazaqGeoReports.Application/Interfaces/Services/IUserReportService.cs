using QazaqGeoReports.Application.DTOs.Common;
using QazaqGeoReports.Application.DTOs.ReportDtos; 

namespace QazaqGeoReports.Application.Interfaces.Services;

public interface IUserReportService
{
    Task<ResultDto<List<BaseReportDto>>> GetUserReportsAsync(string userId);
}
