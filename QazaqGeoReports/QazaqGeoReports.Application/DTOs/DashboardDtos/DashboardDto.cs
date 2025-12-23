namespace QazaqGeoReports.Application.DTOs.DashboardDtos;

public class DashboardDto
{
    public int UsersTotal { get; set; }
    public int UsersActive { get; set; }

    public int ReportsTotal { get; set; }
    public int ReportsToday { get; set; }
    public int ReportsProblem { get; set; }
    public int EquipmentBroken { get; set; }

    public int MissionsActive { get; set; }
    public int MissionsOverdue { get; set; }
}
