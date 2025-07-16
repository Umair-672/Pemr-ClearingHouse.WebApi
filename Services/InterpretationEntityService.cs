using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class InterpretationEntityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "InterpretationEntities";

        public InterpretationEntityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<InterpretationEntity>> GetAllAsync()
            => (await _unitOfWork.Repository<InterpretationEntity>(_collectionName).GetAllAsync()).ToList();

        public async Task<InterpretationEntity?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<InterpretationEntity>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(InterpretationEntity entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.CreatedBy)) entity.CreatedBy = "System";
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = entity.CreatedBy;
            await _unitOfWork.Repository<InterpretationEntity>(_collectionName).AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(string id, InterpretationEntity entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = "System";
            await _unitOfWork.Repository<InterpretationEntity>(_collectionName).UpdateAsync(id, entity);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _unitOfWork.Repository<InterpretationEntity>(_collectionName).DeleteAsync(id);
            return true;
        }
    }
} 