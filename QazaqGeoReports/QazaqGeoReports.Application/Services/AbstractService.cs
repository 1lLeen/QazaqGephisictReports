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

    public virtual async Task<ResultDto<DtoBase>?> GetAsync(Expression<Func<TEntity, bool>> predicate)
    { 
        var res = mapper.Map<DtoBase>(await _repository.GetAsync(predicate));
        if(res is null)
        {
            return new ResultDto<DtoBase>
            {
                Success = false,
                Error = "DTO entity is null"
            };
        }
        return new ResultDto<DtoBase>
        {
            Success = true,
            Data = mapper.Map<DtoBase>(res)
        };

    }
    public virtual async Task<ResultDto<List<DtoBase>>> GetAllAsync() 
    {
        var entities = await _repository.GetAllAsync();
        return ResultBuilder.BuildList<DtoBase, TEntity>(entities, mapper);
    }
    public virtual async Task<ResultDto<DtoBase>> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return ResultBuilder.Build<DtoBase, TEntity>(entity, mapper);
    }
    public virtual async Task<ResultDto<DtoBase>> CreateAsync(DtoCreate entity)
    {
        var created = await _repository.CreateAsync(mapper.Map<TEntity>(entity));
        return ResultBuilder.Build<DtoBase, TEntity>(created, mapper);
    }
    public virtual async Task<ResultDto<DtoBase>> UpdateAsync(DtoUpdate entity) 
    {
        var updated = await _repository.UpdateAsync(mapper.Map<TEntity>(entity));
        return ResultBuilder.Build<DtoBase, TEntity>(updated, mapper);

    }
    public virtual async Task<ResultDto<DtoBase>> DeleteAsync(int id)
    {
        var deleted = await _repository.DeleteAsync(id);
        return ResultBuilder.Build<DtoBase, TEntity>(deleted, mapper);
    }
}
