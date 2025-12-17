using QazaqGeoReports.Application.DTOs.DashboardDtos;

namespace QazaqGeoReports.Application.Interfaces.Services;

public interface IDashboardService
{
    Task<DashboardDto> GetAsync();
}
