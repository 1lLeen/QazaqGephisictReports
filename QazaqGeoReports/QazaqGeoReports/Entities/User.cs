using Microsoft.AspNetCore.Identity;
using QazaqGeoReports.Domain.Common;

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
    public int? PositionId { get; set; }
    public Position? Position { get; set; }

    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }
    public AvailabilityStatus AvailabilityStatus { get; set; }
    public EmploymentStatus EmploymentStatus { get; set; }
    public bool IsActive { get; set; } 
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}
