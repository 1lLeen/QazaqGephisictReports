using QazaqGeoReports.Application.DTOs.Common;
using QazaqGeoReports.Application.DTOs.ReportDtos;
using QazaqGeoReports.Application.DTOs.UserDtos; 

namespace QazaqGeoReports.Application.Interfaces.Services;
public interface IReportService : IAbstractService<BaseReportDto, CreateReportDto, UpdateReportDto>
{
    Task<List<BaseReportDto>> GetReportsByUserAsync(string userId);
    Task<BaseUserDto> GetUserByReportIdAsync(int reportId);
    Task DeleteAllDataReportAsync(int reportId);
    Task<int> GetReportCountByUserId(string userId);
    string TripDuratation(BaseReportDto report);
    string FuelPer100(BaseReportDto report); 
    string TripBadgeText(BaseReportDto report);
    Task ApproveReportAsync(int reportId);
}
