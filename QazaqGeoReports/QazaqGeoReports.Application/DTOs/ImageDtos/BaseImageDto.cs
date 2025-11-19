using QazaqGeoReports.Application.Interfaces.Dtos;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.DTOs.ImageDtos;

public class BaseImageDto : IBase
{
    public int Id { get; set; }
    public byte[] Data { get; set; }
    public string? UserId { get; set; }
    public User? User { get; set; }
    public int? ReportId { get; set; }
    public Report? Report { get; set; }
    public int? EquipmentId { get; set; }
    public Equipment Equipment { get; set; }
}
