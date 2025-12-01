using Microsoft.AspNetCore.Identity;
using QazaqGeoReports.Domain.Entities.Images;

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

    public bool IsActive { get; set; }
    public List<ImageUser> Images { get; set; } = new();
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}
