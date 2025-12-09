using AutoMapper;
using QazaqGeoReports.Application.DTOs.ImageDtos.ImageEquiomentDtos;
using QazaqGeoReports.Application.Interfaces.Repositories.ImagesRepositories;
using QazaqGeoReports.Application.Interfaces.Services.ImagesServices;
using QazaqGeoReports.Domain.Entities.Images;

namespace QazaqGeoReports.Application.Services.ImagesServices;

public class ImageEquipementService :
    AbstractImageService<IImageEquipmentRepository, ImageEquipment, CreateImageEquipmentDto, UpdateImageEquipmentDto, BaseImageEquipmentDto, ListImageEquipmentViewModel>,
    IImageEquipmentService
{
    public ImageEquipementService(IImageEquipmentRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
