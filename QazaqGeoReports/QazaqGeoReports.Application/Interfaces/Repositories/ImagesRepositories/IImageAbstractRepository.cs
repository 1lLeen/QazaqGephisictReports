using QazaqGeoReports.Domain.Entities.Images;
using System.Linq.Expressions;

namespace QazaqGeoReports.Application.Interfaces.Repositories.ImagesRepositories;

public interface IImageAbstractRepository<T> where T : BaseImage
{
    Task<T> GetByIdAsync(int id); 
    Task<List<T>> GetAllAsync();
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(int id);
}
