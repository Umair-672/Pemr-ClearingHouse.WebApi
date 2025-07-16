using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class InterpretedResponseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "InterpretedResponses";

        public InterpretedResponseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<InterpretedResponse>> GetAllAsync()
            => (await _unitOfWork.Repository<InterpretedResponse>(_collectionName).GetAllAsync()).ToList();

        public async Task<InterpretedResponse?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<InterpretedResponse>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(InterpretedResponse entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.CreatedBy)) entity.CreatedBy = "System";
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = entity.CreatedBy;
            await _unitOfWork.Repository<InterpretedResponse>(_collectionName).AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(string id, InterpretedResponse entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = "System";
            await _unitOfWork.Repository<InterpretedResponse>(_collectionName).UpdateAsync(id, entity);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _unitOfWork.Repository<InterpretedResponse>(_collectionName).DeleteAsync(id);
            return true;
        }
    }
} 