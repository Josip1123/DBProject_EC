using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace Data.Repositories;

public class ProjectsRepository(DataContext context) : BaseRepository<ProjectEntity>(context)
{
    public override async Task<List<ProjectEntity>> GetAllAsync()
    {
        var projectsWithRelatedTables = await context.Projects
            .Include(p => p.Owners)
            .Include(p => p.Services)
            .Include(p => p.Customers)
            .ToListAsync();
        
        
        return projectsWithRelatedTables;
    }
}