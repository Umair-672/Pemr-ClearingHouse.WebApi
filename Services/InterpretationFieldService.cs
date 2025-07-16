using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class InterpretationFieldService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "InterpretationFields";

        public InterpretationFieldService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<InterpretationField>> GetAllAsync()
            => (await _unitOfWork.Repository<InterpretationField>(_collectionName).GetAllAsync()).ToList();

        public async Task<InterpretationField?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<InterpretationField>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(InterpretationField entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.CreatedBy)) entity.CreatedBy = "System";
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = entity.CreatedBy;
            await _unitOfWork.Repository<InterpretationField>(_collectionName).AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(string id, InterpretationField entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = "System";
            await _unitOfWork.Repository<InterpretationField>(_collectionName).UpdateAsync(id, entity);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _unitOfWork.Repository<InterpretationField>(_collectionName).DeleteAsync(id);
            return true;
        }
    }
} 
 