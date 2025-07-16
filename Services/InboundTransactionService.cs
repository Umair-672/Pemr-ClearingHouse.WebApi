using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class InboundTransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "InboundTransactions";

        public InboundTransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<InboundTransaction>> GetAllAsync()
            => (await _unitOfWork.Repository<InboundTransaction>(_collectionName).GetAllAsync()).ToList();

        public async Task<InboundTransaction?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<InboundTransaction>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(InboundTransaction entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.CreatedBy)) entity.CreatedBy = "System";
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = entity.CreatedBy;
            await _unitOfWork.Repository<InboundTransaction>(_collectionName).AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(string id, InboundTransaction entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = "System";
            await _unitOfWork.Repository<InboundTransaction>(_collectionName).UpdateAsync(id, entity);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _unitOfWork.Repository<InboundTransaction>(_collectionName).DeleteAsync(id);
            return true;
        }
    }
} 