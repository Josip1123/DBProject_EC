using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace Data.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlite("Data Source=/Users/josipsmac/Desktop/EC_utbildning/Csharp/DBProject_EC/Data/MyDatabse.db");

        return new DataContext(optionsBuilder.Options);
    }
}