using QazaqGeoReports.Domain.Common;

namespace QazaqGeoReports.Domain.Entities;
public class Image : BaseEntity
{
    public byte[] Data { get; set; }
    public string? UserId { get; set; }
    public int? ReportId { get; set; }
    public int? EquipmentId { get; set; }
} 
