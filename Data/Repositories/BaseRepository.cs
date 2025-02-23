using System.Linq.Expressions;
using Data.Contexts;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.Repositories;

public abstract class BaseRepository<T>(DataContext context) : IBaseRepository<T> where T: class
{
    
    private readonly DbSet<T> _dbSet = context.Set<T>();
    private IDbContextTransaction? _dbTransaction;
    
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
        return entity;
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

    #region Transaction

    public virtual async Task BeginTransactionAsync()
    {
        _dbTransaction ??= await context.Database.BeginTransactionAsync();
    }

    public virtual async Task CommitTransactionAsync()
    {
        if (_dbTransaction != null)
        {
            await _dbTransaction.CommitAsync();
            await _dbTransaction.DisposeAsync();
            _dbTransaction = null;
        }
    }

    public virtual async Task RollbackAsync()
    {
        if (_dbTransaction != null)
        {
            await _dbTransaction.RollbackAsync();
            await _dbTransaction.DisposeAsync();
            _dbTransaction = null;
        }
    }
    #endregion
}