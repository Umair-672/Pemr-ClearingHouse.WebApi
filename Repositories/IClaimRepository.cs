using System.Collections.Generic;
using System.Threading.Tasks;
using PemrClearingHouse.Api.Entities;

namespace Repositories
{
    public interface IClaimRepository : IRepository<Claim>
    {
        Task<IEnumerable<Claim>> GetClaimsBySubscriberIdAsync(string subscriberId);
    }
} 