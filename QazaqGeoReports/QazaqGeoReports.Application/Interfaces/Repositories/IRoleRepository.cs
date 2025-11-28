using Microsoft.AspNetCore.Identity;

namespace QazaqGeoReports.Application.Interfaces.Repositories;

public interface IRoleRepository
{
    Task<IdentityRole> GetRoleByNameAsync(string roleName);

}
