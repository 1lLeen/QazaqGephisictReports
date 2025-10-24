using QazaqGeoReports.Domain.Common;

namespace QazaqGeoReports.Domain.Interfaces.Repositories;
public interface IAbstractRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(int id);
}
