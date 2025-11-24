using QazaqGeoReports.Application.DTOs.ReportDtos;

namespace QazaqGeoReports.Application.DTOs.UserDtos;

public class UserViewModel
{
    public BaseUserDto User { get; set; }
    public string? Role { get; set; }
    public string? UserName { get; set; }
    public string? FullName { get; set; }
    public List<BaseReportDto> Reports { get; set; }

    public int ReportCount
    {
        get
        {
            return Reports?.Count ?? 0;
        }
        set 
        {
            ReportCount = Reports?.Count ?? 0;
        }
    } 
}
