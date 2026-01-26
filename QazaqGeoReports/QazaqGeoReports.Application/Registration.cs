using Microsoft.Extensions.DependencyInjection;
using QazaqGeoReports.Application.Mapper;
using QazaqGeoReports.Application.Services;
using QazaqGeoReports.Application.Interfaces.Services; 

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
        services.AddAutoMapper(typeof(MissionMapperProfile));
        services.AddAutoMapper(typeof(EquipmentMapperProfile));
        services.AddAutoMapper(typeof(LocationMapperProfile));
        services.AddAutoMapper(typeof(DepartmentMapperProfile));
    }
    public static void RegistrationServices(this IServiceCollection services)
    {
        services.AddTransient<IRoleService, RoleService>(); 
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IImageService, ImageService>();
        services.AddTransient<IEquipmentService, EquipmentService>();
        services.AddTransient<IReportService, ReportService>();
        services.AddTransient<ICarService, CarService>();
        services.AddTransient<ITaskItemService, TaskItemService>();
        services.AddTransient<IDashboardService, DashboardService>();  
        services.AddTransient<IGalleryService, GalleryService>();
        services.AddTransient<IMissionService, MissionService>();
    }
}

