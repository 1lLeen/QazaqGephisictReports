using AutoMapper;
using QazaqGeoReports.Application.DTOs.ImageDtos.ImageEquiomentDtos; 
using QazaqGeoReports.Domain.Entities.Images;

namespace QazaqGeoReports.Application.Mapper.ImagesMapper;

public class ImageEquipmentMapperProfile : Profile
{
    public ImageEquipmentMapperProfile() 
    {
        CreateMap<BaseImageEquipmentDto, ImageEquipment>().ReverseMap();
        CreateMap<CreateImageEquipmentDto, Image>().ReverseMap();
        CreateMap<UpdateImageEquipmentDto, Image>().ReverseMap();
        CreateMap<ListImageEquipmentViewModel, Image>().ReverseMap();
    }
}
