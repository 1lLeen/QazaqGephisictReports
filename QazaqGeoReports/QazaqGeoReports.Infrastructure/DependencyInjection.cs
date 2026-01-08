using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QazaqGeoReports.Application;
using QazaqGeoReports.Application.Interfaces.Repositories; 
using QazaqGeoReports.Infrastructure.Repositories;

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
        services.AddTransient<IImageRepository, ImageRepository>(); 
        services.AddTransient<IMissionRepository, MissionRepository>();
        services.AddTransient<ITaskItemRepository, TaskItemRepository>();
    }
}
