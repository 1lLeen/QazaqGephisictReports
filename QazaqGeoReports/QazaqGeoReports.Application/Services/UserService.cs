using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Domain.Interfaces.Repositories;
using QazaqGeoReports.Domain.Interfaces.Services;

namespace QazaqGeoReports.Application.Services;
public class UserService : IUserService
{
    protected readonly IUserRepository _repository;
    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }
    public virtual async Task<List<User>> GetAllAsync() => await _repository.GetAllAsync();
    public virtual async Task<User> GetByFullNameAsync(string fullName) => await _repository
        .GetAsync(x => x.FullName == fullName);
    public virtual async Task<User> GetUserByIdAsync(string id) => await _repository.GetUserByIdAsync(id);
    public virtual async Task<User> GetUserByEmailAsync(string email) => await _repository
        .GetAsync(x => x.Email == email);
    public virtual async Task<User> CreateAsync(User entity) => await _repository.CreateAsync(entity);
    public virtual async Task<User> UpdateAsync(User entity) => await _repository.UpdateAsync(entity);
    public virtual async Task<User> DeleteAsync(string id) => await _repository.DeleteAsync(id);
}
