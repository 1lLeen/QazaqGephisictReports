using QazaqGeoReports.Application.DTOs.ReportDtos;

namespace QazaqGeoReports.Application.DTOs.UserDtos;

public class UserDetailsDto
{
    public BaseUserDto User { get; set; }
    public List<BaseReportDto> Reports { get; set; }
    public string? Role { get; set; }
}
