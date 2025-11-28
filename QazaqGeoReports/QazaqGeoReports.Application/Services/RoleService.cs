using Microsoft.AspNetCore.Identity;
using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Application.Interfaces.Services;

namespace QazaqGeoReports.Application.Services;

public class RoleService : IRoleService
{
    protected readonly IRoleRepository _repository;
    public RoleService(IRoleRepository repository)
    {
        _repository = repository;
    }
    public async Task<IdentityRole> GetRoleByNameAsync(string roleName)
    {
        return await _repository.GetRoleByNameAsync(roleName);
    }
}
