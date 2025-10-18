namespace QazaqGeoReports.Application.DTOs;
public class UserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string FullName
    {
        get
        {
            return $"{LastName} {FirstName} {MiddleName}".Trim();
        }
    }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int RoleId { get; set; }
}
