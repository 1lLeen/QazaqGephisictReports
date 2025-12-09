using AutoMapper;
using QazaqGeoReports.Application.DTOs.ImageDtos.ImageReportDtos;
using QazaqGeoReports.Domain.Entities.Images;

namespace QazaqGeoReports.Application.Mapper.ImagesMapper;

public class ImageReportMapperProfile : Profile
{
    public ImageReportMapperProfile()
    {
        CreateMap<BaseImageReportDto, ImageReport>().ReverseMap();
        CreateMap<CreateImageReportDto, ImageReport>().ReverseMap();
        CreateMap<UpdateImageReportDto, ImageReport>().ReverseMap();
        CreateMap<ListImageReportViewModel, ImageReport>().ReverseMap();

    }
}
