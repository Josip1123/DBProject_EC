using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IBaseRepository<T> where T : class
{
      Task AddAsync(T entity);
      Task<List<T>> GetAllAsync(); 
      Task<T> GetAsync(Expression<Func<T, bool>> expression);
      Task DeleteAsync(T entity);
      Task UpdateAsync(T entity);

      Task BeginTransactionAsync();
      Task CommitTransactionAsync();

      Task RollbackAsync();
}