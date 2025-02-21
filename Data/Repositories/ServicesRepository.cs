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
}