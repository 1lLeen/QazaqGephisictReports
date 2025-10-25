using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Domain.Interfaces.Repositories;
public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User> GetUserByIdAsync(string id);
    Task<User> GetUserByEmailAsync(string email);
    Task<User> GetByFullNameAsync(string fullName);
    Task<User> GetUserByFirstNameAsync(string firtsName);
    Task<User> GetUserByLastNameAsync(string lastName);
    Task<User> GetUserByMiddleNameAsync(string middleName);
    Task<User> GetUserByPhoneAsync(string phone);
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(User user);
    Task<User> DeleteAsync(string id);

}
