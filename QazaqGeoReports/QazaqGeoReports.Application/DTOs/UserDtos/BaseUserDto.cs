using QazaqGeoReports.Application.Interfaces.Dtos;

namespace QazaqGeoReports.Application.DTOs.UserDtos;

public class BaseUserDto : IBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Email { get; set; }
    public string FullName
    {
        get
        {
            return $"{LastName} {FirstName} {MiddleName}".Trim();
        }
    } 
}
