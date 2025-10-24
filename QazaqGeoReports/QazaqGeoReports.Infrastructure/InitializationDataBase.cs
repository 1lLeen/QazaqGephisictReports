using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; 
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
         
        dbContext.Database.EnsureDeleted();
        dbContext.Database.Migrate();

        var admin = GetInitialUser();
        admin.PasswordHash = new PasswordHasher<User>().HashPassword(admin, "NewPasswordForMe1112");
        
        dbContext.Roles.AddRange(GetRoles());
        dbContext.SaveChanges();  
         
        dbContext.Users.Add(admin);
        dbContext.SaveChanges(); 

        dbContext.RoleClaims.Add(new IdentityRoleClaim<string>
        {
            RoleId = dbContext.Roles.First(x => x.Name == Roles.Admin.ToString()).Id.ToString(),
            ClaimType = "IsAdmin",
            ClaimValue = "true"
        });
        dbContext.SaveChanges();

        dbContext.UserRoles.Add(new IdentityUserRole<string>
        {
            RoleId = dbContext.Roles.First(x => x.Name == Roles.Admin.ToString()).Id.ToString(),
            UserId = dbContext.Users.First().Id
        });
        dbContext.SaveChanges();

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
                NormalizedName = Roles.Worker.ToString().ToUpper(),
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
public class IdentitySeeder
{
    public static async Task SeedAllAsync(IServiceProvider serviceProvider)
    { 
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        await SeedRoles(roleManager);
        await SeedUser(serviceProvider);
    }
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

    public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
    {        
        var roles = Enum.GetNames(typeof(Roles));

        foreach (var roleName in roles)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole{
                    Name = roleName,
                    NormalizedName = roleName.ToUpper()
                });
            }
        }
    }
    public static async Task SeedUser(IServiceProvider sp)
    {
        var userMgr = sp.GetRequiredService<UserManager<User>>();
        var role = Roles.Admin.ToString();

        var email = "mygoldencode@gmail.com";
        var existingUser = await userMgr.FindByEmailAsync(email);

        if (existingUser == null)
        {
            var admin = GetInitialUser();
            var result = await userMgr.CreateAsync(admin, "NewPasswordForMe12!");

            if (!result.Succeeded)
            {
                throw new Exception("Не удалось создать пользователя: " +
                    string.Join("; ", result.Errors.Select(e => e.Description)));
            }

            await userMgr.AddToRoleAsync(admin, role);
        }
        else
        {
            Console.WriteLine("Пользователь уже существует — пропущено создание");
            if (!await userMgr.IsInRoleAsync(existingUser, role))
            {
                await userMgr.AddToRoleAsync(existingUser, role);
            }
        }
    }

}