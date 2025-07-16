using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class InsuranceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "Insurances";

        public InsuranceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Insurance>> GetAllAsync()
            => (await _unitOfWork.Repository<Insurance>(_collectionName).GetAllAsync()).ToList();

        public async Task<Insurance?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<Insurance>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(Insurance entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.CreatedBy)) entity.CreatedBy = "System";
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = entity.CreatedBy;
            await _unitOfWork.Repository<Insurance>(_collectionName).AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(string id, Insurance entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = "System";
            await _unitOfWork.Repository<Insurance>(_collectionName).UpdateAsync(id, entity);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _unitOfWork.Repository<Insurance>(_collectionName).DeleteAsync(id);
            return true;
        }
    }
} 