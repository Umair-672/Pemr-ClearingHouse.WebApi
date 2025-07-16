using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class InsuranceCarrierService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "InsuranceCarriers";

        public InsuranceCarrierService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<InsuranceCarrier>> GetAllAsync()
            => (await _unitOfWork.Repository<InsuranceCarrier>(_collectionName).GetAllAsync()).ToList();

        public async Task<InsuranceCarrier?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<InsuranceCarrier>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(InsuranceCarrier entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.CreatedBy)) entity.CreatedBy = "System";
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = entity.CreatedBy;
            await _unitOfWork.Repository<InsuranceCarrier>(_collectionName).AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(string id, InsuranceCarrier entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = "System";
            await _unitOfWork.Repository<InsuranceCarrier>(_collectionName).UpdateAsync(id, entity);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _unitOfWork.Repository<InsuranceCarrier>(_collectionName).DeleteAsync(id);
            return true;
        }
    }
} 