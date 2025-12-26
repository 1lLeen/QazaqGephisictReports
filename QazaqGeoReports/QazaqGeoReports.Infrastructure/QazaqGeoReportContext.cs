using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QazaqGeoReports.Domain.Entities; 
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
    public DbSet<Mission> Missions { get; set; }  
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new BaseConfiguration<Report>());
        builder.ApplyConfiguration(new BaseConfiguration<Equipment>());
        builder.ApplyConfiguration(new BaseConfiguration<Image>());
        builder.ApplyConfiguration(new BaseConfiguration<Mission>());
        builder.ApplyConfiguration(new BaseConfiguration<TaskItem>());
        builder.ApplyConfiguration(new BaseConfiguration<Car>());

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
