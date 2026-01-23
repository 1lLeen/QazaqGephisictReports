using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using QazaqGeoReports.Domain.Common;
using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Infrastructure;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile("appsettings.Development.json", optional: true)
    .AddEnvironmentVariables();

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 10 * 1024 * 1024; // 10MB
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<QazaqGeoReportContext>(options =>
    options.UseNpgsql(connectionString));

builder.AddInfrastructureServices();

builder.Services
    .AddIdentity<User, IdentityRole>(o =>
    {
        o.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<QazaqGeoReportContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanSeeAllReports", p =>
        p.RequireRole(nameof(Roles.Admin), nameof(Roles.Supervisor), nameof(Roles.General)));
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();


var app = builder.Build();
 
var supportedCultures = new[] { new CultureInfo("ru-RU") };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("ru-RU"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});
 
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<QazaqGeoReportContext>();
    db.Database.Migrate();

    await IdentitySeeder.SeedAllAsync(scope.ServiceProvider);
}
 
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler();
    app.UseHsts();
}

app.MapHealthChecks("/health");

app.UseHttpsRedirection(); 

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
