using QazaqGeoReports.Application.DTOs.ReportDtos;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Interfaces.Services;
public interface IReportService : IAbstractService<BaseReportDto, CreateReportDto, UpdateReportDto>
{
    Task<List<BaseReportDto>> GetReportsByUserAsync(string userId);
    Task<User> GetUserByReportIdAsync(int reportId);
    Task DeleteAllDataReportAsync(int reportId);
    string TripDuratation(Report report);
    string FuelPer100(Report report); 
    string TripBadgeText(Report report);

}
