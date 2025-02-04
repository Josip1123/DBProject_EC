using Data.Contexts;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public abstract class BaseRepository<T>(DataContext context) : IBaseRepository<T> where T: class
{
    
    private readonly DbSet<T> _dbSet = context.Set<T>();
    
    public virtual async Task<T> AddAsync(T entity)
    {
       throw new NotImplementedException();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T> Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T> Update(T entity)
    {
        throw new NotImplementedException();
    }
}