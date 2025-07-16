using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class ResponseKeywordService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "ResponseKeywords";

        public ResponseKeywordService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ResponseKeyword>> GetAllAsync()
            => (await _unitOfWork.Repository<ResponseKeyword>(_collectionName).GetAllAsync()).ToList();

        public async Task<ResponseKeyword?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<ResponseKeyword>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(ResponseKeyword entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.CreatedBy)) entity.CreatedBy = "System";
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = entity.CreatedBy;
            await _unitOfWork.Repository<ResponseKeyword>(_collectionName).AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(string id, ResponseKeyword entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = "System";
            await _unitOfWork.Repository<ResponseKeyword>(_collectionName).UpdateAsync(id, entity);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _unitOfWork.Repository<ResponseKeyword>(_collectionName).DeleteAsync(id);
            return true;
        }
    }
} 