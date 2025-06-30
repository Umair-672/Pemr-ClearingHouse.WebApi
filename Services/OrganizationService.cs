using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PemrClearingHouse.Api.Configurations;
using PemrClearingHouse.Api.Entities;

namespace PemrClearingHouse.Api.Services
{
    public class OrganizationService
    {
        private readonly IMongoCollection<OrganizationEntity> _collection;

        public OrganizationService(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _collection = database.GetCollection<OrganizationEntity>(settings.Value.CollectionName);
        }

        public async Task<List<OrganizationEntity>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<OrganizationEntity?> GetByIdAsync(string id) =>
            await _collection.Find(o => o.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(OrganizationEntity org)
        {
            org.CreatedAt = DateTime.UtcNow;
            org.UpdatedAt = DateTime.UtcNow;
            await _collection.InsertOneAsync(org);
        }

        public async Task<bool> UpdateAsync(string id, OrganizationEntity org)
        {
            org.UpdatedAt = DateTime.UtcNow;
            org.Id = id;
            var result = await _collection.ReplaceOneAsync(o => o.Id == id, org);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _collection.DeleteOneAsync(o => o.Id == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }
    }
}
