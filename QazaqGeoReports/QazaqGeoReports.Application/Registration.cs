using Microsoft.Extensions.DependencyInjection;
using QazaqGeoReports.Application.Mapper;
using QazaqGeoReports.Application.Services;
using QazaqGeoReports.Application.Interfaces.Services;
using QazaqGeoReports.Application.Mapper.ImagesMapper;
using QazaqGeoReports.Application.Interfaces.Services.ImagesServices;
using QazaqGeoReports.Application.Services.ImagesServices;
using QazaqGeoReports.Application.Mapper.MissionsMapper;
using QazaqGeoReports.Application.Services.MissionsServices;
using QazaqGeoReports.Application.Interfaces.Services.MissionsRepositories;

namespace QazaqGeoReports.Application;
public static class RegistrationApplication
{
    public static void RegistrationAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserMapperProfile));
        services.AddAutoMapper(typeof(EquipmentMapperProfile));
        services.AddAutoMapper(typeof(ReportMapperProfile));
        services.AddAutoMapper(typeof(ImageMapperProfile));
        services.AddAutoMapper(typeof(TaskItemMapperProfile));
        services.AddAutoMapper(typeof(CarMapperProfile));
        #region AddImagesMapper
        services.AddAutoMapper(typeof(ImageEquipmentMapperProfile));
        services.AddAutoMapper(typeof(ImageReportMapperProfile));
        services.AddAutoMapper(typeof(ImageUserMapperProfile));
        services.AddAutoMapper(typeof(ImageCarMapperProfile));
        #endregion
        #region Missions
        services.AddAutoMapper(typeof(MissionMapperProfile));
        services.AddAutoMapper(typeof(CarMissionMapperProfile));
        services.AddAutoMapper(typeof(EquipmentMapperProfile));
        #endregion
    }
    public static void RegistrationServices(this IServiceCollection services)
    {
        services.AddTransient<IRoleService, RoleService>(); 
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IEquipmentService, EquipmentService>();
        services.AddTransient<IReportService, ReportService>();
        services.AddTransient<ICarService, CarService>();
        services.AddTransient<ITaskItemService, TaskItemService>();
        services.AddTransient<IDashboardService, DashboardService>();
        #region ImageServices
        services.AddTransient<IImageEquipmentService, ImageEquipementService>();
        services.AddTransient<IImageReportService, ImageReportService>();
        services.AddTransient<IImageUserService, ImageUserService>();
        #endregion
        #region MissionsService
        services.AddTransient<IMissionService, MissionService>();
        services.AddTransient<ICarMissionService, CarMissionService>();
        services.AddTransient<IEquipmentMissionService, EquipmentMissionService>();
        #endregion
    }
}

