using QazaqGeoReports.Application.Interfaces.Dtos;

namespace QazaqGeoReports.Application.Interfaces.Services.ImagesServices;

public interface IImageAbstractService<TDtoBase, TCreateDto, TUpdateDto>
    where TDtoBase : IBase
    where TCreateDto : ICreate
    where TUpdateDto : IUpdate
{
    Task<List<TDtoBase>> GetImagesAsync();
    Task<TDtoBase> GetImageByIdAsync(int id);
    Task<TDtoBase> CreateAsync(TCreateDto entity);
    Task<TDtoBase> UpdateAsync(TUpdateDto entity, int id);
    Task<TDtoBase> DeleteAsync(int id);
    string GetDataUrl(TDtoBase img);
    string GuessMime(byte[] bytes);
}
