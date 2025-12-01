using AutoMapper;
using QazaqGeoReports.Application.DTOs.ImageDtos;
using QazaqGeoReports.Domain.Entities.Images;

namespace QazaqGeoReports.Application.Mapper;

public class ImageMapperProfile : Profile
{
    public ImageMapperProfile() 
    {
        CreateMap<BaseImageDto, Image>().ReverseMap();
        CreateMap<CreateImageDto, Image>().ReverseMap();
        CreateMap<UpdateImageDto, Image>().ReverseMap();
        CreateMap<ListImageViewModel, Image>().ReverseMap();
    }
}
