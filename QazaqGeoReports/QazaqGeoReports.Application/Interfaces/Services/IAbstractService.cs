using QazaqGeoReports.Application.DTOs.Common;
using QazaqGeoReports.Application.Interfaces.Dtos;

namespace QazaqGeoReports.Application.Interfaces.Services;
public interface IAbstractService<TDtoBase, TCreateDto, TUpdateDto>
    where TDtoBase : IBase
    where TCreateDto : ICreate
    where TUpdateDto : IUpdate
{
    Task<TDtoBase> GetByIdAsync(int id);
    Task<List<TDtoBase>> GetAllAsync();
    Task<TDtoBase> CreateAsync(TCreateDto entity);
    Task<TDtoBase> UpdateAsync(TUpdateDto entity, int id);
    Task<TDtoBase> DeleteAsync(int id);
}
