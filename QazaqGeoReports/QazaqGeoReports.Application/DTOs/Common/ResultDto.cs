namespace QazaqGeoReports.Application.DTOs.Common;

public class ResultDto<T>
{
    public bool Success { get; set; } = true;
    public string? Error { get; set; }
    public T? Data { get; set; }
}
