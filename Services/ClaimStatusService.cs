using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class ClaimStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "ClaimStatuses";

        public ClaimStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ClaimStatus>> GetAllAsync()
            => (await _unitOfWork.Repository<ClaimStatus>(_collectionName).GetAllAsync()).ToList();

        public async Task<ClaimStatus?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<ClaimStatus>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(ClaimStatus entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.CreatedBy)) entity.CreatedBy = "System";
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = entity.CreatedBy;
            await _unitOfWork.Repository<ClaimStatus>(_collectionName).AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(string id, ClaimStatus entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = "System";
            await _unitOfWork.Repository<ClaimStatus>(_collectionName).UpdateAsync(id, entity);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _unitOfWork.Repository<ClaimStatus>(_collectionName).DeleteAsync(id);
            return true;
        }
    }
} 