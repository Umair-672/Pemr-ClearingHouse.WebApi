using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class OutboundTransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "OutboundTransactions";

        public OutboundTransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<OutboundTransaction>> GetAllAsync()
            => (await _unitOfWork.Repository<OutboundTransaction>(_collectionName).GetAllAsync()).ToList();

        public async Task<OutboundTransaction?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<OutboundTransaction>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(OutboundTransaction entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.CreatedBy)) entity.CreatedBy = "System";
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = entity.CreatedBy;
            await _unitOfWork.Repository<OutboundTransaction>(_collectionName).AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(string id, OutboundTransaction entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = "System";
            await _unitOfWork.Repository<OutboundTransaction>(_collectionName).UpdateAsync(id, entity);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _unitOfWork.Repository<OutboundTransaction>(_collectionName).DeleteAsync(id);
            return true;
        }
    }
} 