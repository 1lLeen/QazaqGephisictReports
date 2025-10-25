using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Domain.Interfaces.Services;
public interface IUserService
{
    Task<List<User>> GetAllAsync();
    Task<User> GetByFullNameAsync(string fullName);
    Task<User> GetUserByIdAsync(string id);
    Task<User> GetUserByEmailAsync(string email);
    Task<User> CreateAsync(User entity);
    Task<User> UpdateAsync(User entity);
    Task<User> DeleteAsync(string id);

}
