using AutoMapper; 
using QazaqGeoReports.Application.DTOs.ImageDtos.ImageEquiomentDtos;
using QazaqGeoReports.Domain.Entities.Images;
using QazaqGeoReports.Application.DTOs.ImageDtos.ImageUserDtos;

namespace QazaqGeoReports.Application.Mapper;

public class ImageMapperProfile : Profile
{
    public ImageMapperProfile() 
    {
        CreateMap<BaseImageUserDto, Image>().ReverseMap();
        CreateMap<CreateImageUserDto, Image>().ReverseMap();
        CreateMap<UpdateImageUserDto, Image>().ReverseMap();
        CreateMap<ListImageUserViewModel, Image>().ReverseMap();
    }
}
