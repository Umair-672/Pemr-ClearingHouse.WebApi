using System;
using System.Collections.Concurrent;
using PemrClearingHouse.Api.Configurations;
using Repositories;

namespace PemrClearingHouse.Api.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MongoDbContext _context;
        private readonly ConcurrentDictionary<string, object> _repositories = new();

        public UnitOfWork(MongoDbContext context)
        {
            _context = context;
        }

        public IRepository<T> Repository<T>(string collectionName) where T : class
        {
            var key = $"{typeof(T).FullName}_{collectionName}";
            if (!_repositories.ContainsKey(key))
            {
                var repo = new BaseRepository<T>(_context, collectionName);
                _repositories[key] = repo;
            }
            return (IRepository<T>)_repositories[key];
        }

        public Task SaveChangesAsync()
        {
            // MongoDB operations are committed immediately, so this is a no-op
            return Task.CompletedTask;
        }
    }
} 