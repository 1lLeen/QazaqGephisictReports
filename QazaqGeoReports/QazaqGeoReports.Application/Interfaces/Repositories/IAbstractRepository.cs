using QazaqGeoReports.Domain.Entities;
using System.Linq.Expressions;

namespace QazaqGeoReports.Application.Interfaces.Repositories;
public interface IAbstractRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    Task<List<T>> GetAllAsync();
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(int id);
}
