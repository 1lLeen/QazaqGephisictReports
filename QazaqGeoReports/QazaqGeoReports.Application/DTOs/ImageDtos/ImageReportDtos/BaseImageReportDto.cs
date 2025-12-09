using QazaqGeoReports.Application.Interfaces.Dtos;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.DTOs.ImageDtos.ImageReportDtos;

public class BaseImageReportDto : IImageBase
{
    public int Id { get; set; }
    public byte[] Data { get; set; }
    public int ReportId { get; set; }
    public Report Report { get; set; }
}