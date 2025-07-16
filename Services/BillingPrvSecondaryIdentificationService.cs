using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class BillingPrvSecondaryIdentificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "BillingPrvSecondaryIdentifications";

        public BillingPrvSecondaryIdentificationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<BillingPrvSecondaryIdentification>> GetAllAsync()
            => (await _unitOfWork.Repository<BillingPrvSecondaryIdentification>(_collectionName).GetAllAsync()).ToList();

        public async Task<BillingPrvSecondaryIdentification?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<BillingPrvSecondaryIdentification>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(BillingPrvSecondaryIdentification entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.CreatedBy)) entity.CreatedBy = "System";
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = entity.CreatedBy;
            await _unitOfWork.Repository<BillingPrvSecondaryIdentification>(_collectionName).AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(string id, BillingPrvSecondaryIdentification entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = "System";
            await _unitOfWork.Repository<BillingPrvSecondaryIdentification>(_collectionName).UpdateAsync(id, entity);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _unitOfWork.Repository<BillingPrvSecondaryIdentification>(_collectionName).DeleteAsync(id);
            return true;
        }
    }
} 