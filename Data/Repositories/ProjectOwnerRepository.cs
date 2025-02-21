using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProjectOwnerRepository(DataContext context) : BaseRepository<ProjectOwnerEntity>(context)
{
    public override async Task<List<ProjectOwnerEntity>> GetAllAsync()
    {
        var ownersWithProject = await context.ProjectOwner
            .Include(p => p.Project)
            .ToListAsync();
        
        return ownersWithProject;
    }
}