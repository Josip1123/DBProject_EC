using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace Data.Repositories;

public class CustomersRepository(DataContext context) : BaseRepository<CustomersEntity>(context)
{
    public override async Task<List<CustomersEntity>> GetAllAsync()
    {
        var ownersWithProject = await context.Customer
            .Include(p => p.Project)
            .ToListAsync();
        
        return ownersWithProject;
    }
    

    public override async Task<CustomersEntity> GetAsync(Expression<Func<CustomersEntity, bool>> expression)
    {
        var entity = await context.Customer.Include(c => c.Project).FirstOrDefaultAsync(expression);
        if (entity == null)
            throw new KeyNotFoundException("Entity not found.");
        return entity!;
    }
}