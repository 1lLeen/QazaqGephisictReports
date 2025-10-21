using Microsoft.Extensions.DependencyInjection;
using QazaqGeoReports.Application.Mapper;
using QazaqGeoReports.Application.Services;
using QazaqGeoReports.Domain.Interfaces.Services;

namespace QazaqGeoReports.Application;
public static class RegistrationApplication
{
    public static void RegistrationAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
    }
    public static void RegistrationServices(this IServiceCollection services)
    {
        services.AddTransient<IImageService, ImageService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IEquipmentService, EquipmentService>();
        services.AddTransient<IReportService, ReportService>();
    }
}

