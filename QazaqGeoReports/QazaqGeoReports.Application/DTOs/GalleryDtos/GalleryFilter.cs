namespace QazaqGeoReports.Application.DTOs.GalleryDtos;

public class GalleryFilter
{
    public string? SourceType { get; init; }  
    public DateTime? From { get; init; }
    public DateTime? To { get; init; }
    public string? Search { get; init; }  

    public int Page { get; init; } = 1;
    public int PageSize { get; init; } = 30;
}
public sealed class PagedResult<T>
{
    public required IReadOnlyList<T> Items { get; init; }
    public required int Page { get; init; }
    public required int PageSize { get; init; }
    public required int TotalCount { get; init; }
}