using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class FTPSettingsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "FTPSettings";

        public FTPSettingsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<FTPSettings>> GetAllAsync()
            => (await _unitOfWork.Repository<FTPSettings>(_collectionName).GetAllAsync()).ToList();

        public async Task<FTPSettings?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<FTPSettings>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(FTPSettings entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.CreatedBy)) entity.CreatedBy = "System";
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = entity.CreatedBy;
            await _unitOfWork.Repository<FTPSettings>(_collectionName).AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(string id, FTPSettings entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = "System";
            await _unitOfWork.Repository<FTPSettings>(_collectionName).UpdateAsync(id, entity);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _unitOfWork.Repository<FTPSettings>(_collectionName).DeleteAsync(id);
            return true;
        }
    }
} 