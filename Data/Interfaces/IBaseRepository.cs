namespace Data.Interfaces;

public interface IBaseRepository<T> where T : class
{
      Task<T> AddAsync(T entity);
      Task<IEnumerable<T>> GetAllAsync();
      public Task<T> Delete(T entity);
      public Task<T> Update(T entity);
}