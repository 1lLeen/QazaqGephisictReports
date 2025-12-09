using AutoMapper;
using QazaqGeoReports.Application.DTOs.ImageDtos.ImageUserDtos;
using QazaqGeoReports.Domain.Entities.Images;

namespace QazaqGeoReports.Application.Mapper.ImagesMapper;

public class ImageUserMapperProfile : Profile
{
    public ImageUserMapperProfile()
    {
        CreateMap<BaseImageUserDto, ImageUser>().ReverseMap();
        CreateMap<CreateImageUserDto, ImageUser>().ReverseMap();
        CreateMap<UpdateImageUserDto, ImageUser>().ReverseMap();
        CreateMap<ListImageUserViewModel, ImageUser>().ReverseMap();
    }
}
