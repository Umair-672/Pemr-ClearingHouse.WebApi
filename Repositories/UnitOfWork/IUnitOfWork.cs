using Repositories;
using System.Threading.Tasks;

namespace PemrClearingHouse.Api.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>(string collectionName) where T : class;
        Task SaveChangesAsync();
    }
} 