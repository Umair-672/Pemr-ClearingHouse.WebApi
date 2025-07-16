using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Configurations;

namespace Repositories
{
    public class ClaimRepository : BaseRepository<Claim>, IClaimRepository
    {
        public ClaimRepository(MongoDbContext context,
            string collectionName)
            : base
            (context, collectionName)
        {
        }

        public async Task<IEnumerable<Claim>> GetClaimsBySubscriberIdAsync(string subscriberId)
        {
            var filter = Builders<Claim>.Filter.Eq(c => c.SubscriberID, subscriberId);
            return await _collection.Find(filter).ToListAsync();
        }
    }
} 