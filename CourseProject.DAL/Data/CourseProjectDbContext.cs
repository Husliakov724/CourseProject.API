using CourseProject.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.DAL.Data;

public class CourseProjectDbContext : DbContext
{
    public DbSet<Indicator> Indicators { get; set; }
    public DbSet<IndicatorValue> IndicatorValues { get; set; }
    public DbSet<BackgroundImage> BackgroundImages { get; set; }

    public CourseProjectDbContext(DbContextOptions<CourseProjectDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\\\MSSQLLocalDB;Initial Catalog=CourseProjectAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Indicator>()
            .HasMany(e => e.IndicatorValues)
            .WithOne(v => v.Indicator)
            .OnDelete(DeleteBehavior.Cascade);
    }
}