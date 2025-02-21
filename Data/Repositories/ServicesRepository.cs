using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ServicesRepository(DataContext context) : BaseRepository<ServicesEntity>(context)
{
    public override async Task<List<ServicesEntity>> GetAllAsync()
    {
        var ownersWithProject = await context.Services
            .Include(p => p.Project)
            .ToListAsync();
        
        return ownersWithProject;
    }
    public override async Task<ServicesEntity> GetAsync(Expression<Func<ServicesEntity, bool>> expression)
    {
        var entity = await context.Services.Include(c => c.Project).FirstOrDefaultAsync(expression);
        if (entity == null)
            throw new KeyNotFoundException("Entity not found.");
        return entity!;
    }
}