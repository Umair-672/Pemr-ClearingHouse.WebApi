using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class SubscriberService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "Subscribers";

        public SubscriberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Subscriber>> GetAllAsync()
            => (await _unitOfWork.Repository<Subscriber>(_collectionName).GetAllAsync()).ToList();

        public async Task<Subscriber?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<Subscriber>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(Subscriber entity)
            => await _unitOfWork.Repository<Subscriber>(_collectionName).AddAsync(entity);

        public async Task UpdateAsync(string id, Subscriber entity)
            => await _unitOfWork.Repository<Subscriber>(_collectionName).UpdateAsync(id, entity);

        public async Task DeleteAsync(string id)
            => await _unitOfWork.Repository<Subscriber>(_collectionName).DeleteAsync(id);
    }
} 