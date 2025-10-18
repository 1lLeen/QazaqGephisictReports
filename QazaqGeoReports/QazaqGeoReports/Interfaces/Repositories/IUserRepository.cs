using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Domain.Interfaces.Repositories;
public interface IUserRepository
{
    Task<User> GetUserById(string id);
}
