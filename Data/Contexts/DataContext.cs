using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext : DbContext
{

    public DbSet<CustomersEntity> Customer { get; set; }
    
    public DbSet<ProjectEntity> Projects { get; set; }
    
    public DbSet<ProjectOwnerEntity> ProjectOwner { get; set; }
    
    public DbSet<ServicesEntity> Services { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) 
        {
            optionsBuilder.UseSqlite("Data Source=/Users/josipsmac/Desktop/EC utbildning/Csharp/DBProject_EC/Data/MyDatabase.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<ServicesEntity>()
            .Property(p => p.Price)
            .HasColumnType("REAL");
        
        modelBuilder.Entity<ProjectEntity>()
            .Property(o => o.DateCreated)
            .HasColumnType("TEXT");
        
        modelBuilder.Entity<ProjectEntity>()
            .Property(o => o.DateDue)
            .HasColumnType("TEXT");
        
       modelBuilder.Entity<ProjectEntity>()
            .HasMany(p => p.Owners)
            .WithOne(p => p.Project)
            .HasForeignKey(p => p.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
       
       modelBuilder.Entity<ProjectEntity>()
           .HasMany(p => p.Customers)
           .WithOne(p => p.Project)
           .HasForeignKey(p => p.ProjectId)
           .OnDelete(DeleteBehavior.Cascade);
       
       modelBuilder.Entity<ProjectEntity>()
           .HasMany(p => p.Services)
           .WithOne(p => p.Project)
           .HasForeignKey(p => p.ProjectId)
           .OnDelete(DeleteBehavior.Cascade);
        
       
    }

}