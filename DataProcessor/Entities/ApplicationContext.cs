using Microsoft.EntityFrameworkCore;

namespace DataProcessor.Entities;

public class ApplicationContext : DbContext
{
    public DbSet<ModuleStatusEntity> ModuleStates { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ModuleStatusEntity>()
            .HasKey(e => e.ModuleCategoryID);

        base.OnModelCreating(modelBuilder);
    }
}
