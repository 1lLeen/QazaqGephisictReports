namespace QazaqGeoReports.Application.DTOs.GalleryDtos;

public class GalleryImageDto
{
    public int Id { get; init; }
    public byte[] Data { get; init; } 
    public DateTime CreatedTime { get; init; }

    public int ReportId { get; init; }
    public string? ReportTitle { get; init; }

    public string ContentType { get; init; } = "image/jpeg";
} 
