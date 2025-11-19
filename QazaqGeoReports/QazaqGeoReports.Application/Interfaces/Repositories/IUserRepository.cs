using QazaqGeoReports.Domain.Entities;
using System.Linq.Expressions;

namespace QazaqGeoReports.Application.Interfaces.Repositories;
public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User> GetUserByIdAsync(string id);
    Task<User?> GetAsync(Expression<Func<User, bool>> predicate); 
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(User user);
    Task<User> DeleteAsync(string id);

}
