using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class ClaimEntityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "ClaimEntities";

        public ClaimEntityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ClaimEntity>> GetAllAsync()
            => (await _unitOfWork.Repository<ClaimEntity>(_collectionName).GetAllAsync()).ToList();

        public async Task<ClaimEntity?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<ClaimEntity>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(ClaimEntity entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.CreatedBy)) entity.CreatedBy = "System";
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = entity.CreatedBy;
            await _unitOfWork.Repository<ClaimEntity>(_collectionName).AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(string id, ClaimEntity entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = "System";
            await _unitOfWork.Repository<ClaimEntity>(_collectionName).UpdateAsync(id, entity);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _unitOfWork.Repository<ClaimEntity>(_collectionName).DeleteAsync(id);
            return true;
        }
    }
} 