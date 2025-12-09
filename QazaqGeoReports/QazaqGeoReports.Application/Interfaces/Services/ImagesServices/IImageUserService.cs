using QazaqGeoReports.Application.DTOs.ImageDtos.ImageUserDtos;

namespace QazaqGeoReports.Application.Interfaces.Services.ImagesServices;

public interface IImageUserService : 
    IImageAbstractService<BaseImageUserDto, CreateImageUserDto, UpdateImageUserDto>
{
}
