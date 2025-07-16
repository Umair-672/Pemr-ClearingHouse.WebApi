using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class InterpretedResponseFieldService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "InterpretedResponseFields";

        public InterpretedResponseFieldService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<InterpretedResponseField>> GetAllAsync()
            => (await _unitOfWork.Repository<InterpretedResponseField>(_collectionName).GetAllAsync()).ToList();

        public async Task<InterpretedResponseField?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<InterpretedResponseField>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(InterpretedResponseField entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.CreatedBy)) entity.CreatedBy = "System";
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = entity.CreatedBy;
            await _unitOfWork.Repository<InterpretedResponseField>(_collectionName).AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(string id, InterpretedResponseField entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = "System";
            await _unitOfWork.Repository<InterpretedResponseField>(_collectionName).UpdateAsync(id, entity);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _unitOfWork.Repository<InterpretedResponseField>(_collectionName).DeleteAsync(id);
            return true;
        }
    }
} 