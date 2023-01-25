using MongodbApp.Interfaces;

namespace MongodbApp.Services;
public class BaseRepository<T> : IRepository<T> where T : class
{

    private readonly IMongoServices<T> _repository;
    public BaseRepository(IMongoServices<T> repository)
    {
        _repository = repository;
    }
    public async Task<T> GetAsync(string id)
    {
        var entity = await _repository.GetById(id);
        return entity;
    }
    public async Task<List<T>> GetAllAsync()
    {
        var lstEntity = await _repository.GetAllAsync();
        return lstEntity;
    }
    public async Task<T> CreateAsync(T entity)
    {
        return await _repository.AddAsync(entity);
    }
    public async Task<T> UpdateAsync(string id, T entity)
    {
        return await _repository.UpdateAsync(id, entity);
    }
    public async Task DeleteAsync(string id, T entity)
    {
        await _repository.DeleteAsync(id, entity);
    }

}
