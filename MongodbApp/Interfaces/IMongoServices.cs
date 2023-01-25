using MongoDB.Driver;

namespace MongodbApp.Interfaces;
public interface IMongoServices<T>
{
    IMongoClient Client { get; }
    IMongoDatabase Database { get; }
    Task<IMongoCollection<T>> GetCollection(string collectionName);
    Task<T> GetById(string id);
    Task<List<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(string id, T entity);
    Task<T> DeleteAsync(string id, T entity);

}
