using AutoMapper;
using QazaqGeoReports.Application.DTOs.ImageDtos.ImageUserDtos;
using QazaqGeoReports.Application.Interfaces.Repositories.ImagesRepositories;
using QazaqGeoReports.Application.Interfaces.Services.ImagesServices;
using QazaqGeoReports.Domain.Entities.Images;

namespace QazaqGeoReports.Application.Services.ImagesServices;

public class ImageUserService : AbstractImageService<IImageUserRepository, ImageUser, CreateImageUserDto, UpdateImageUserDto, BaseImageUserDto, ListImageUserViewModel>,
    IImageUserService
{
    public ImageUserService(IImageUserRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
