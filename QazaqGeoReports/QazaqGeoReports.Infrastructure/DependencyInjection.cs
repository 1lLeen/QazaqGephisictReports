using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QazaqGeoReports.Application;
using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Application.Interfaces.Repositories.ImagesRepositories;
using QazaqGeoReports.Application.Interfaces.Repositories.MissionsRepositories;
using QazaqGeoReports.Infrastructure.Repositories;
using QazaqGeoReports.Infrastructure.Repositories.ImagesRepositories;
using QazaqGeoReports.Infrastructure.Repositories.MissionsRepositories;

namespace QazaqGeoReports.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
    {
        builder.Services.RegistrationAutoMapper();
        builder.Services.RegistrationRepositories();
        builder.Services.RegistrationServices();
    }
    public static void RegistrationRepositories(this IServiceCollection services)
    {
        services.AddTransient<IRoleRepository, RoleRepository>(); 
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IEquipmentRepository, EquipmentRepository>();
        services.AddTransient<IReportRepository, ReportRepository>();
        services.AddTransient<ICarRepository, CarRepository>();
        services.AddTransient<ITaskItemRepository, TaskItemRepository>();
        #region ImagesRepositories
        services.AddTransient<IImageEquipmentRepository, ImageEquipmentRepository>();
        services.AddTransient<IImageReportRepository, ImageReportRepository>();
        services.AddTransient<IImageUserRepository, ImageUserRepository>();
        #endregion
        #region MissionsRepositories
        services.AddTransient<IMissionRepository, MissionRepository>();
        services.AddTransient<ICarMissionRepository, CarMissionRepository>();
        services.AddTransient<IEquipmentMissionRepository, EquipmentMissionRepository>();
        #endregion
    }
}
