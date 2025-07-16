using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class GatewayService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "Gateways";

        public GatewayService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Gateway>> GetAllAsync()
            => (await _unitOfWork.Repository<Gateway>(_collectionName).GetAllAsync()).ToList();

        public async Task<Gateway?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<Gateway>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(Gateway entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.CreatedBy)) entity.CreatedBy = "System";
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = entity.CreatedBy;
            await _unitOfWork.Repository<Gateway>(_collectionName).AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(string id, Gateway entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = "System";
            await _unitOfWork.Repository<Gateway>(_collectionName).UpdateAsync(id, entity);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _unitOfWork.Repository<Gateway>(_collectionName).DeleteAsync(id);
            return true;
        }
    }
} 