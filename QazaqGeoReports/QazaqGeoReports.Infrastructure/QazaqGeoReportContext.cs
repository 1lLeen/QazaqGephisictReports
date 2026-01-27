using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Domain.Entities.Missions;
using QazaqGeoReports.Infrastructure.Configurations; 

namespace QazaqGeoReports.Infrastructure;

public class QazaqGeoReportContext(DbContextOptions<QazaqGeoReportContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; } 
    public DbSet<Image> Images { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<PositionRole> PositionRoles { get; set; }
    public DbSet<Department> Departments { get; set; }
    #region missions
    public DbSet<Mission> Missions { get; set; }
    public DbSet<MissionMember> MissionMembers { get; set; }
    public DbSet<MissionCar> MissionCars { get; set; }
    public DbSet<MissionDriverAssignment> MissionDrivers { get; set; }
    #endregion
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new BaseConfiguration<Report>());
        builder.ApplyConfiguration(new BaseConfiguration<Equipment>());
        builder.ApplyConfiguration(new BaseConfiguration<Image>());
        builder.ApplyConfiguration(new BaseConfiguration<Mission>());
        builder.ApplyConfiguration(new BaseConfiguration<TaskItem>());
        builder.ApplyConfiguration(new BaseConfiguration<Car>());
        builder.ApplyConfiguration(new BaseConfiguration<MissionMember>());
        builder.ApplyConfiguration(new BaseConfiguration<MissionCar>());
        builder.ApplyConfiguration(new BaseConfiguration<MissionDriverAssignment>());
        builder.ApplyConfiguration(new BaseConfiguration<Location>());
        builder.ApplyConfiguration(new BaseConfiguration<Position>());
        builder.ApplyConfiguration(new BaseConfiguration<PositionRole>());
        builder.ApplyConfiguration(new BaseConfiguration<Department>());
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
