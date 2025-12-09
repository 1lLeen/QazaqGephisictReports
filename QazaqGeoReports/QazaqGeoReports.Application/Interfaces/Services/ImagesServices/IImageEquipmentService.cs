using QazaqGeoReports.Application.DTOs.ImageDtos.ImageEquiomentDtos;

namespace QazaqGeoReports.Application.Interfaces.Services.ImagesServices;

public interface IImageEquipmentService : 
    IImageAbstractService<BaseImageEquipmentDto, CreateImageEquipmentDto, UpdateImageEquipmentDto>
{
}
