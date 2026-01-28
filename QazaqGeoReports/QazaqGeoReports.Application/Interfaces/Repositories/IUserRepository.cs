using QazaqGeoReports.Domain.Common;
using QazaqGeoReports.Domain.Entities.Users;
using System.Linq.Expressions;

namespace QazaqGeoReports.Application.Interfaces.Repositories;
public interface IUserRepository
{
    Task<List<User>> GetAllAsync();  
    Task<List<User>> GetUsersByRoleAsync(Roles role);
    Task<User> GetUserByIdAsync(string id);
    Task<User?> GetAsync(Expression<Func<User, bool>> predicate);
    Task<string> GetRoleByUserIdAsync(string userId);
    public Task<int> UsersCountAsync();
    public Task<int> UsersActivceCountAsync();
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(User user);
    Task<User> DeleteAsync(string id);

}
