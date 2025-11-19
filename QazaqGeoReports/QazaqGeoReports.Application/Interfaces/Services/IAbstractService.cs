using QazaqGeoReports.Application.DTOs.Common;
using QazaqGeoReports.Application.Interfaces.Dtos;

namespace QazaqGeoReports.Application.Interfaces.Services;
public interface IAbstractService<TDtoBase, TCreateDto, TUpdateDto>
    where TDtoBase : IBase
    where TCreateDto : ICreate
    where TUpdateDto : IUpdate
{
    Task<ResultDto<TDtoBase>> GetByIdAsync(int id);
    Task<ResultDto<List<TDtoBase>>> GetAllAsync();
    Task<ResultDto<TDtoBase>> CreateAsync(TCreateDto entity);
    Task<ResultDto<TDtoBase>> UpdateAsync(TUpdateDto entity);
    Task<ResultDto<TDtoBase>> DeleteAsync(int id);
}
