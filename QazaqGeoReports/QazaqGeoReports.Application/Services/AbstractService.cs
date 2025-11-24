using AutoMapper;
using QazaqGeoReports.Application.DTOs.Common;
using QazaqGeoReports.Application.DTOs.Helpers;
using QazaqGeoReports.Application.Interfaces.Dtos;
using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Domain.Entities; 
using System.Linq.Expressions; 

namespace QazaqGeoReports.Application.Services;
public class AbstractService<TRepository, TEntity, DtoCreate, DtoUpdate, DtoBase, DtoList> 
    where TRepository : IAbstractRepository<TEntity> 
    where TEntity : BaseEntity, new()
    where DtoCreate : ICreate
    where DtoUpdate : IUpdate
    where DtoBase : IBase
    where DtoList : IListView
{
    protected readonly TRepository _repository;
    protected ResultDto<DtoBase> _resultDto = new ResultDto<DtoBase>();
    protected IMapper mapper; 

    public AbstractService(TRepository repository, IMapper mapper)
    {
        _repository = repository;
        this.mapper = mapper;
    }

    public virtual async Task<DtoBase>? GetAsync(Expression<Func<TEntity, bool>> predicate)
    { 
        var res = mapper.Map<DtoBase>(await _repository.GetAsync(predicate));
        return mapper.Map<DtoBase>(res);

    }
    public virtual async Task<List<DtoBase>> GetAllAsync() 
    {
        var entities = await _repository.GetAllAsync();
        return mapper.Map<List<DtoBase>>(entities);
    }
    public virtual async Task<DtoBase> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return mapper.Map<DtoBase>(entity);
    }
    public virtual async Task<DtoBase> CreateAsync(DtoCreate entity)
    {
        var created = await _repository.CreateAsync(mapper.Map<TEntity>(entity));
        return mapper.Map<DtoBase>(created);
    }
    public virtual async Task<DtoBase> UpdateAsync(DtoUpdate entity) 
    {
        var updated = await _repository.UpdateAsync(mapper.Map<TEntity>(entity));
        return mapper.Map<DtoBase>(updated);

    }
    public virtual async Task<DtoBase> DeleteAsync(int id)
    {
        var deleted = await _repository.DeleteAsync(id);
        return mapper.Map<DtoBase>(deleted);
    }
}
