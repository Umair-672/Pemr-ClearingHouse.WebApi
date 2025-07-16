using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class RTTransactionSettingsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "RTTransactionSettings";

        public RTTransactionSettingsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<RTTransactionSettings>> GetAllAsync()
            => (await _unitOfWork.Repository<RTTransactionSettings>(_collectionName).GetAllAsync()).ToList();

        public async Task<RTTransactionSettings?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<RTTransactionSettings>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(RTTransactionSettings entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.CreatedBy)) entity.CreatedBy = "System";
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = entity.CreatedBy;
            await _unitOfWork.Repository<RTTransactionSettings>(_collectionName).AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(string id, RTTransactionSettings entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = "System";
            await _unitOfWork.Repository<RTTransactionSettings>(_collectionName).UpdateAsync(id, entity);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _unitOfWork.Repository<RTTransactionSettings>(_collectionName).DeleteAsync(id);
            return true;
        }
    }
} 