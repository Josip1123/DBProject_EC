namespace Data.Interfaces;

public interface IBaseRepository<T> where T : class
{
      Task<T> AddAsync(T entity);
      Task<IEnumerable<T>> GetAllAsync();
      Task<T> Delete(T entity);
      Task<T> Update(T entity);
}