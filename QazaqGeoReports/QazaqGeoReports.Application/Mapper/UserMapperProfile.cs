using AutoMapper;
using QazaqGeoReports.Application.DTOs.UserDtos;
using QazaqGeoReports.Application.DTOs.UserDtos.AuthDtos;
using QazaqGeoReports.Domain.Entities.Users;

namespace QazaqGeoReports.Application.Mapper;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<BaseUserDto, User>().ReverseMap();
        CreateMap<CreateUserDto, User>().ReverseMap();
        CreateMap<UpdateUserDto, User>().ReverseMap();
        CreateMap<UserDetailsDto, User>().ReverseMap();
        CreateMap<UserLite, User>().ReverseMap();
        CreateMap<UserViewModel, User>().ReverseMap();
        CreateMap<RegisterDto, User>().ReverseMap();
        CreateMap<LoginDto, User>().ReverseMap();
    }
}
