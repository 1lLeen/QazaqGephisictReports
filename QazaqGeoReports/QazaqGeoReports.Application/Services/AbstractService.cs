using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace QazaqGeoReports.Application.Services;
public class AbstractService<TRepository, TEntity, DtoCreate, DtoUpdate, DtoBase, DtoList> 
    where TRepository : IAbstractRepository<TEntity> 
    where TEntity : BaseEntity, new()

{
    protected readonly TRepository _repository;
    public AbstractService(TRepository repository)
    {
        _repository = repository;
    }
    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate) => await _repository.GetAsync(predicate);
    public virtual async Task<List<TEntity>> GetAllAsync() => await _repository.GetAllAsync();
    public virtual async Task<TEntity> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public virtual async Task<TEntity> CreateAsync(TEntity entity) => await _repository.CreateAsync(entity);
    public virtual async Task<TEntity> UpdateAsync(TEntity entity) => await _repository.UpdateAsync(entity);
    public virtual async Task<TEntity> DeleteAsync(int id) => await _repository.DeleteAsync(id);
}
