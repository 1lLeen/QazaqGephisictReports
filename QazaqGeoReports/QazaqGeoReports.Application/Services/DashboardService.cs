using QazaqGeoReports.Application.DTOs.DashboardDtos;
using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Application.Interfaces.Services;
using QazaqGeoReports.Domain.Common;

namespace QazaqGeoReports.Application.Services;

public class DashboardService : IDashboardService
{
    private readonly IUserRepository _users;
    private readonly IReportRepository _reports;
    private readonly IEquipmentRepository _equipment;
    private readonly IMissionRepository _missions;
    public DashboardService(
        IUserRepository users,
        IReportRepository reports,
        IEquipmentRepository equipment,
        IMissionRepository missions)
    {
        _users = users;
        _reports = reports;
        _equipment = equipment;
        _missions = missions;
    }
    public async Task<DashboardDto> GetAsync()
    {
        return new DashboardDto
        {
            UsersTotal = await _users.UsersCountAsync(),
            UsersActive = await _users.UsersActivceCountAsync(),

            ReportsTotal = (await _reports.GetAllAsync()).Count,
            ReportsToday = await _reports.CountTodayAsync(),
            ReportsProblem = await _reports.CountByStatusAsync(ReportStatus.Rejected),

            EquipmentBroken = await _equipment.CountByStatusAsync(EquipmentStatus.UnderMaintenance),

            MissionsActive = await _missions.CountActiveAsync(),
            MissionsOverdue = await _missions.CountOverdueAsync()
        };
    }
}