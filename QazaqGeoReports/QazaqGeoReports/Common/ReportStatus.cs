namespace QazaqGeoReports.Domain.Common;

public enum ReportStatus
{
    Draft,
    Submitted,
    ReviewRequired,
    Approved,
    Rejected,
    Archived,
}
public enum ReportType
{
    MissionType,
    CarType,
    EquipmentType,
}