using QazaqGeoReports.Application.Interfaces.Dtos;

namespace QazaqGeoReports.Application.DTOs.UserDtos;

public class BaseUserDto : IBase
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string? JobTitle { get; set; }
    public string? Note { get; set; }
    public string? PersonnelNumber { get; set; }
    public bool IsActive { get; set; }
    public string FullName
    {
        get
        {
            return $"{LastName} {FirstName} {MiddleName}".Trim();
        }
    } 
    public string ViewFullName
    {
        get
        {
            string Cut(string s) =>
                s.Length > 8 ? s.Substring(0, 8) + "…" : s;

            return $"{Cut(LastName)} {Cut(FirstName)}";
        }
    }
}
