using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{

    public DbSet<CustomersEntity> Customer { get; set; }
    
    public DbSet<ProjectEntity> Projects { get; set; }
    
    public DbSet<ProjectOwnerEntity> ProjectOwner { get; set; }
    
    public DbSet<ServicesEntity> Services { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) 
        {
            optionsBuilder.UseSqlite("Data Source=MyDatabase.db");
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
        
        modelBuilder.Entity<ProjectOwnerEntity>()
            .HasMany(po => po.Projects)
            .WithOne(p => p.Owner)
            .HasForeignKey(p => p.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<ProjectEntity>()
            .HasMany(u => u.Customers)
            .WithMany(p => p.Projects)
            .UsingEntity<Dictionary<string, object>>(
                "ProjectCustomer",  
                j => j
                    .HasOne<CustomersEntity>()
                    .WithMany()
                    .HasForeignKey("Id")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<ProjectEntity>()
                    .WithMany()
                    .HasForeignKey("Id")
                    .OnDelete(DeleteBehavior.Cascade)
            );
        
        modelBuilder.Entity<ProjectEntity>()
            .HasMany(u => u.Services)
            .WithMany(p => p.Projects)
            .UsingEntity<Dictionary<string, object>>(
                "ProjectServices",  
                j => j
                    .HasOne<ServicesEntity>()
                    .WithMany()
                    .HasForeignKey("Id")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<ProjectEntity>()
                    .WithMany()
                    .HasForeignKey("Id")
                    .OnDelete(DeleteBehavior.Cascade)
            );
        
        modelBuilder.Entity<ServicesEntity>()
            .HasMany(u => u.Customers)
            .WithMany(p => p.Services)
            .UsingEntity<Dictionary<string, object>>(
                "CustomerServices",  
                j => j
                    .HasOne<CustomersEntity>()
                    .WithMany()
                    .HasForeignKey("Id")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<ServicesEntity>()
                    .WithMany()
                    .HasForeignKey("Id")
                    .OnDelete(DeleteBehavior.Cascade)
            );
    }

}