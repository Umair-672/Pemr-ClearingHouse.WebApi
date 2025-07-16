using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class X12StandardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "X12Standards";

        public X12StandardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<X12Standard>> GetAllAsync()
            => (await _unitOfWork.Repository<X12Standard>(_collectionName).GetAllAsync()).ToList();

        public async Task<X12Standard?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<X12Standard>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(X12Standard entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.CreatedBy)) entity.CreatedBy = "System";
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = entity.CreatedBy;
            await _unitOfWork.Repository<X12Standard>(_collectionName).AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(string id, X12Standard entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = "System";
            await _unitOfWork.Repository<X12Standard>(_collectionName).UpdateAsync(id, entity);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _unitOfWork.Repository<X12Standard>(_collectionName).DeleteAsync(id);
            return true;
        }
    }
} 