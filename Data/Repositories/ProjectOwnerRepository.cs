using System.Linq.Expressions;
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
    
    public override async Task<ProjectOwnerEntity> GetAsync(Expression<Func<ProjectOwnerEntity, bool>> expression)
    {
        var entity = await context.ProjectOwner.Include(c => c.Project).FirstOrDefaultAsync(expression);
        if (entity == null)
            throw new KeyNotFoundException("Entity not found.");
        return entity!;
    }
}