using QazaqGeoReports.Application.DTOs.ImageDtos;

namespace QazaqGeoReports.Application.Interfaces.Services;

public interface IImageService : IAbstractService<BaseImageDto, CreateImageDto, UpdateImageDto>
{
    string GetDataUrl(BaseImageDto img);
    string GuessMime(byte[] bytes);
}
