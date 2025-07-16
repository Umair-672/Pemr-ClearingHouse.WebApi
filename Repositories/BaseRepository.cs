using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using System.Reflection;
using PemrClearingHouse.Api.Configurations;

namespace Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly IMongoCollection<T> _collection;

        public BaseRepository(MongoDbContext context, string collectionName)
        {
            _collection = context.GetCollection<T>(collectionName);
        }

        private PropertyInfo GetIdProperty()
        {
            return typeof(T).GetProperties()
                .FirstOrDefault(p => Attribute.IsDefined(p, typeof(BsonIdAttribute)))
                ?? typeof(T).GetProperty(typeof(T).Name + "ID")
                ?? throw new InvalidOperationException("No ID property found for this entity.");
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var idProp = GetIdProperty();
            var filter = Builders<T>.Filter.Eq(idProp.Name, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(string id, T entity)
        {
            var idProp = GetIdProperty();
            idProp.SetValue(entity, id);
            var filter = Builders<T>.Filter.Eq(idProp.Name, id);
            await _collection.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteAsync(string id)
        {
            var idProp = GetIdProperty();
            var filter = Builders<T>.Filter.Eq(idProp.Name, id);
            await _collection.DeleteOneAsync(filter);
        }
    }
} 