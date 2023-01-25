using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongodbApp.Interfaces;
using MongodbApp.Settings;

namespace MongodbApp.Services
{
    public class MongoServices<T> : IMongoServices<T> where T : class
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<T> _context;
        private readonly MongoSettings _settings;
        public MongoServices(IOptions<MongoSettings> setting)
        {
            _settings = setting.Value;
            _client = new MongoClient(_settings.ConnectionKey);
            _database = _client.GetDatabase(_settings.DatabaseName);
            _context = _database.GetCollection<T>(typeof(T).Name);
        }

        public Task<IMongoCollection<T>> GetCollection(string collectionName)
        {
            var result = Database.GetCollection<T>(collectionName);
            return Task.FromResult(result);
        }
        public async Task<T> GetById(string id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            var result = await _context.FindAsync(filter);
            return result.FirstOrDefault();
        }
        public async Task<List<T>> GetAllAsync()
        {
            var result = await _context.FindAsync<T>(_ => true);
            return result.ToList();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.InsertOneAsync(entity);
            return entity;
        }
        public Task<T> UpdateAsync(string id, T entity)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            _context.ReplaceOne(filter, entity);
            return Task.FromResult(entity);
        }
        public Task<T> DeleteAsync(string id, T entity)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            _context.DeleteOne(filter);
            return Task.FromResult(entity);
        }
        public IMongoClient Client => _client ?? throw new ArgumentNullException();

        public IMongoDatabase Database => _database ?? throw new ArgumentNullException();
    }
}
