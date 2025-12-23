namespace QazaqGeoReports.Application.DTOs.GalleryDtos;

public class GalleryImageDto
{
    public int Id { get; init; }
    public string Url { get; init; } = "";
    public string? Description { get; init; }
    public DateTime CreatedAt { get; init; }

    public int ReportId { get; init; }
    public string? ReportTitle { get; init; }
} 
