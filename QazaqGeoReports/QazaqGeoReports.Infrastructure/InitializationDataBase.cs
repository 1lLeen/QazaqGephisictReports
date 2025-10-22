using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using QazaqGeoReports.Domain.Common;
using QazaqGeoReports.Domain.Entities;
using System.Data;

namespace QazaqGeoReports.Infrastructure;

public class InitializationDataBase
{
    public const string ConnectionString = "DefaultConnection";
    public static void Init(IHost host)
    {
        Console.WriteLine("Init database");
        var config = host.Services.GetRequiredService<IConfiguration>();
        using var scope = host.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<QazaqGeoReportContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<InitializationDataBase>>();

        logger.LogInformation("Database rebuild started.");

        dbContext.Database.EnsureDeleted();
        dbContext.Database.Migrate();

        logger.LogInformation("Started initialization of primary data in the database.");

        var admin = GetInitialUser();
        admin.PasswordHash = new PasswordHasher<User>().HashPassword(admin, "NewPasswordForMe1112");
        dbContext.Roles.AddRange(GetRoles());
        dbContext.Users.Add(admin);
        dbContext.SaveChanges();

        logger.LogInformation("Database rebuild finished.");
    }
    private static List<IdentityRole> GetRoles() => new List<IdentityRole>
        {
            new IdentityRole
            {
                Name = Roles.Admin.ToString(),
                NormalizedName = Roles.Admin.ToString().ToUpper(),
            },
            new IdentityRole
            {
                Name = Roles.General.ToString(),
                NormalizedName = Roles.General.ToString().ToUpper(),
            },new IdentityRole
            {
                Name = Roles.Supervisor.ToString(),
                NormalizedName = Roles.Supervisor.ToString().ToUpper(),
            },new IdentityRole
            {
                Name = Roles.Driver.ToString(),
                NormalizedName = Roles.Driver.ToString().ToUpper(),
            },
            new IdentityRole
            {
                Name = Roles.Worker.ToString(),
                NormalizedName = Roles.Driver.ToString().ToUpper(),
            },
        };
    private static User GetInitialUser() =>
    new User()
    {
        CreatedTime = DateTime.Now.ToUniversalTime(),
        UpdatedTime = DateTime.Now.ToUniversalTime(),
        Email = "mygoldencode@gmail.com", 
        FirstName = "Жангир",
        LastName = "Емишов",
        MiddleName = "Бауржанович",
        UserName = "mygoldencode@gmail.com",
        NormalizedUserName = "mygoldencode@gmail.com".ToUpper().Normalize(),
        NormalizedEmail = "mygoldencode@gmail.com".ToUpper().Normalize(),
        PhoneNumber = "87768236918",
        PhoneNumberConfirmed = true,
        EmailConfirmed = true,

    };
}
