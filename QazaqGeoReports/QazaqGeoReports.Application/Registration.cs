using Microsoft.Extensions.DependencyInjection;
using QazaqGeoReports.Application.Mapper;
using QazaqGeoReports.Application.Services;
using QazaqGeoReports.Application.Interfaces.Services;
using QazaqGeoReports.Application.Mapper.ImagesMapper;
using QazaqGeoReports.Application.Interfaces.Services.ImagesServices;
using QazaqGeoReports.Application.Services.ImagesServices;

namespace QazaqGeoReports.Application;
public static class RegistrationApplication
{
    public static void RegistrationAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserMapperProfile));
        services.AddAutoMapper(typeof(EquipmentMapperProfile));
        services.AddAutoMapper(typeof(ReportMapperProfile));
        services.AddAutoMapper(typeof(ImageMapperProfile));
        #region AddImagesMapper
        services.AddAutoMapper(typeof(ImageEquipmentMapperProfile));
        services.AddAutoMapper(typeof(ImageReportMapperProfile));
        services.AddAutoMapper(typeof(ImageUserMapperProfile));
        #endregion
    }
    public static void RegistrationServices(this IServiceCollection services)
    {
        services.AddTransient<IRoleService, RoleService>(); 
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IEquipmentService, EquipmentService>();
        services.AddTransient<IReportService, ReportService>();
        #region ImageServices
        services.AddTransient<IImageEquipmentService, ImageEquipementService>();
        services.AddTransient<IImageReportService, ImageReportService>();
        services.AddTransient<IImageUserService, ImageUserService>();
        #endregion
    }
}

