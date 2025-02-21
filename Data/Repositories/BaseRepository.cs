using System.Collections.Immutable;
using System.Linq.Expressions;
using Data.Contexts;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public abstract class BaseRepository<T>(DataContext context) : IBaseRepository<T> where T: class
{
    
    private readonly DbSet<T> _dbSet = context.Set<T>();
    
    public virtual async Task AddAsync(T entity)
    {
         await _dbSet.AddAsync(entity);
         await context.SaveChangesAsync();
    }

    public virtual async Task<List<T>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        
        return entities;
    }

    public virtual async Task<T> GetAsync(Expression<Func<T, bool>> expression)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(expression);
        if (entity == null)
            throw new KeyNotFoundException("Entity not found.");
        return entity!;
    }

    public virtual async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        if (entity == null)
            throw new KeyNotFoundException("Entity not found.");
        await context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        if (entity == null)
            throw new KeyNotFoundException("Entity not found.");
        await context.SaveChangesAsync();
    }
}