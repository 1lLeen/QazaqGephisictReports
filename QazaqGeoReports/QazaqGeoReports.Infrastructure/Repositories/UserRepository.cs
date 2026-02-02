using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Domain.Entities.Users;
using System.Linq.Expressions;

namespace QazaqGeoReports.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{

    protected QazaqGeoReportContext _context;
    protected DbSet<User> _dbSet;
    public UserRepository(QazaqGeoReportContext context)
    {
        _context = context;
        _dbSet = _context.Set<User>();
    }
    public async Task<User?> GetByLastNameAsync(string lastName)
    {
        lastName = lastName.Trim();

        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.LastName == lastName);
    }
     
    public async Task<List<User>> SearchByLastNameAsync(string lastName)
    {
        lastName = lastName.Trim();

        return await _context.Users
            .AsNoTracking()
            .Where(u => EF.Functions.ILike(u.LastName, $"%{lastName}%")) 
            .ToListAsync();
    }
    public async Task<List<User>> GetUsersByRoleAsync(Domain.Common.Roles role)
    {
        var roleName = role.ToString();

        var users = await (
            from user in _context.Users
            join userRole in _context.UserRoles on user.Id equals userRole.UserId
            join roleEntity in _context.Roles on userRole.RoleId equals roleEntity.Id
            where roleEntity.Name != null && roleEntity.Name == roleName
            select user
        )
        .AsNoTracking()
        .Distinct()
        .ToListAsync();

        return users;
    }
    public async Task<List<User>> GetAllAsync()
    {
        var res = await _dbSet
            .AsNoTracking()
            .ToListAsync();
        return res;
    }
    public async Task<User> CreateAsync(User model)
    {
        model.CreatedTime = DateTime.UtcNow;
        model.UpdatedTime = DateTime.UtcNow;

        await _dbSet.AddAsync(model);
        await _context.SaveChangesAsync();
        return model;
    }
    public async Task<User> DeleteAsync(string id)
    {
        var model = await GetUserByIdAsync(id);
        _dbSet.Remove(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<User> UpdateAsync(User model)
    {
        model.UpdatedTime = DateTime.UtcNow;
        var local = _context.Set<User>()
            .Local
            .FirstOrDefault(entry => entry.Id.Equals(model.Id));
        if (local != null)
        {
            _context.Entry(local).State = EntityState.Detached;
        }
        var entry = _context.Entry(model);
        entry.State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return model;

    }
    public async Task<User> GetUserByIdAsync(string id) => await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
    public async Task<User?> GetAsync(Expression<Func<User, bool>> predicate)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(predicate);
    }

    public async Task<string> GetRoleByUserIdAsync(string userId)
    {
        var roleId = await _context.UserRoles
        .Where(ur => ur.UserId == userId)
        .Select(ur => ur.RoleId)
        .FirstOrDefaultAsync();

        if (roleId == null)
            return null;

        var roleName = await _context.Roles
            .Where(r => r.Id == roleId)
            .Select(r => r.Name)
            .FirstOrDefaultAsync();

        return roleName;
    } 

    public async Task<int> UsersCountAsync()
    {
        return await _context.Users
            .AsNoTracking()
            .CountAsync();
    }
    public async Task<int> UsersActivceCountAsync()
    {
        return await _context.Users
            .AsNoTracking()
            .CountAsync(u => u.IsActive);
    }
}
