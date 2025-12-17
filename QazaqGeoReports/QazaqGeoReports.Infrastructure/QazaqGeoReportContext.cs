using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Domain.Entities.Images;
using QazaqGeoReports.Domain.Entities.Missions;
using QazaqGeoReports.Infrastructure.Configurations;
using QazaqGeoReports.Infrastructure.Configurations.ImageConfiguration;

namespace QazaqGeoReports.Infrastructure;

public class QazaqGeoReportContext(DbContextOptions<QazaqGeoReportContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }
    #region imgs
    public DbSet<ImageEquipment> ImageEquipments { get; set; }
    public DbSet<ImageReport> ImageReports { get; set; }
    public DbSet<ImageUser> ImageUsers { get; set; }
    public DbSet<ImageCar> ImageCars { get; set; }
    //public DbSet<Image> Images { get; set; }
    #endregion
    #region missions
    public DbSet<Mission> Missions { get; set; }
    public DbSet<CarMission> CarMissions { get; set; }
    public DbSet<EquipmentMission> EquipmentMissions { get; set; }
    #endregion
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new BaseConfiguration<Report>());
        builder.ApplyConfiguration(new BaseConfiguration<Equipment>());
        builder.ApplyConfiguration(new BaseConfiguration<Image>());
        #region ImageConfig
        builder.ApplyConfiguration(new ImageEquipmentConfiguration());
        builder.ApplyConfiguration(new ImageUserConfiguration());
        builder.ApplyConfiguration(new ImageReportConfiguration());
        #endregion
        builder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedTime)
            .HasDefaultValueSql("TIMEZONE('UTC', NOW())");
            entity.Property(e => e.UpdatedTime)
            .HasDefaultValueSql("TIMEZONE('UTC', NOW())");
            entity.HasIndex(e => e.Email).IsUnique();
        });
    }
}
