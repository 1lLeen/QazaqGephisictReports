using QazaqGeoReports.Domain.Entities;
using System.Linq.Expressions;

namespace QazaqGeoReports.Domain.Interfaces.Repositories;
public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User> GetUserByIdAsync(string id);
    Task<User?> GetAsync(Expression<Func<User, bool>> predicate);
    Task<User> GetUserByPhoneAsync(string phone);
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(User user);
    Task<User> DeleteAsync(string id);

}
