using AutoMapper;
using QazaqGeoReports.Application.DTOs.ImageDtos.ImageCarDto;
using QazaqGeoReports.Domain.Entities.Images;

namespace QazaqGeoReports.Application.Mapper.ImagesMapper;

public class ImageCarMapperProfile : Profile
{
    public ImageCarMapperProfile()
    {
        CreateMap<BaseImageCarDto, ImageCar>().ReverseMap();
        CreateMap<CreateImageCarDto, ImageCar>().ReverseMap();
        CreateMap<UpdateImageCarDto, ImageCar>().ReverseMap();
        CreateMap<ListImageCarViewModel, ImageCar>().ReverseMap();
    }
}
