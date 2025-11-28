using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Domain.Common;

namespace QazaqGeoReports.Infrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    protected readonly QazaqGeoReportContext _context;
    public RoleRepository(QazaqGeoReportContext context)
    {
        _context = context;
    }

    public async Task<IdentityRole> GetRoleByNameAsync(string roleName)
    {
        IdentityRole role;

        if (roleName == "none" || roleName is null)
        {
            role = await _context.Roles.FirstOrDefaultAsync(x => x.Name == Roles.Worker.ToString());
        }
        else
        {
            role = await _context.Roles.FirstOrDefaultAsync(x => x.Name == roleName);
        }

        return role;
    }
}
