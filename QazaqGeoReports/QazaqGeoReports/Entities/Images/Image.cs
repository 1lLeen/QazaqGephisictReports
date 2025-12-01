namespace QazaqGeoReports.Domain.Entities;
public class Image : BaseEntity
{
    public byte[] Data { get; set; }
    public string? UserId { get; set; }
    public User? User { get; set; }
    public int? ReportId { get; set; }
    public Report? Report { get; set; }
    public int? EquipmentId { get; set; }
    public Equipment Equipment { get; set; }
} 
