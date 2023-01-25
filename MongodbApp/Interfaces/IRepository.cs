namespace MongodbApp.Interfaces;
public interface IRepository<T>
{
    Task<T> GetAsync(string id);
    Task<List<T>> GetAllAsync();
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(string id, T entity);
    Task DeleteAsync(string id, T entity);
}
