using QazaqGeoReports.Application.Interfaces.Dtos; 
using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Domain.Entities.Users;

namespace QazaqGeoReports.Application.DTOs.ImageDtos;

public class BaseImageDto : IBase
{
    public int Id { get; set; }
    public byte[] Data { get; set; }
    public string? UserId { get; set; }
    public User? User { get; set; }
    public int? ReportId { get; set; } = null;
    public Report? Report { get; set; } = null;
    public int? EquipmentId { get; set; } = null;
    public Equipment? Equipment { get; set; } = null;
    public int? CarId { get; set; }  = null;
    public Car? Car { get; set; } = null;
}
