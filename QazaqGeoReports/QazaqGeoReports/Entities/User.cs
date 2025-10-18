using Microsoft.AspNet.Identity.EntityFramework;

namespace QazaqGeoReports.Domain.Entities;
public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; } 
    public string Email { get; set; }
    public string Phone { get; set; }
    public int RoleId { get; set; }
}
