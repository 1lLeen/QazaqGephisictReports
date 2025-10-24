using Microsoft.AspNetCore.Identity;

namespace QazaqGeoReports.Domain.Entities;
public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; } 
    public string FullName {
        get
        {
            return $"{LastName} {FirstName} {MiddleName}".Trim();
        }
    }
    public string RoleId { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}
