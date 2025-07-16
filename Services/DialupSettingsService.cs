using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class DialupSettingsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "DialupSettings";

        public DialupSettingsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<DialupSettings>> GetAllAsync()
            => (await _unitOfWork.Repository<DialupSettings>(_collectionName).GetAllAsync()).ToList();

        public async Task<DialupSettings?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<DialupSettings>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(DialupSettings settings)
        {
            settings.CreatedAt = DateTime.UtcNow;
            settings.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(settings.CreatedBy)) settings.CreatedBy = "System";
            if (string.IsNullOrEmpty(settings.UpdatedBy)) settings.UpdatedBy = settings.CreatedBy;
            await _unitOfWork.Repository<DialupSettings>(_collectionName).AddAsync(settings);
        }

        public async Task<bool> UpdateAsync(string id, DialupSettings settings)
        {
            settings.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(settings.UpdatedBy)) settings.UpdatedBy = "System";
            await _unitOfWork.Repository<DialupSettings>(_collectionName).UpdateAsync(id, settings);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _unitOfWork.Repository<DialupSettings>(_collectionName).DeleteAsync(id);
            return true;
        }
    }
} 