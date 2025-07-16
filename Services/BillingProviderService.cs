
using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;


namespace PemrClearingHouse.Api.Services
{
    public class BillingProviderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "BillingProviders";

        public BillingProviderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<BillingProvider>> GetAllAsync()
            => (await _unitOfWork.Repository<BillingProvider>(_collectionName).GetAllAsync()).ToList();

        public async Task<BillingProvider?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<BillingProvider>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(BillingProvider entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.CreatedBy)) entity.CreatedBy = "System";
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = entity.CreatedBy;
            await _unitOfWork.Repository<BillingProvider>(_collectionName).AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(string id, BillingProvider entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = "System";
            await _unitOfWork.Repository<BillingProvider>(_collectionName).UpdateAsync(id, entity);
            return true; // Optionally, check for update result if needed
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _unitOfWork.Repository<BillingProvider>(_collectionName).DeleteAsync(id);
            return true; // Optionally, check for delete result if needed
        }

    }
}