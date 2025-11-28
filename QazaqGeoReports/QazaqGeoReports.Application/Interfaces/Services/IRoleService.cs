using Microsoft.AspNetCore.Identity;

namespace QazaqGeoReports.Application.Interfaces.Services;

public interface IRoleService
{
    Task<IdentityRole> GetRoleByNameAsync(string roleName);
}
