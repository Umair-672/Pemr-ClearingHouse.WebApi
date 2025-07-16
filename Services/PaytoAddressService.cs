 using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class PaytoAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "PaytoAddresses";

        public PaytoAddressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PaytoAddress>> GetAllAsync()
            => (await _unitOfWork.Repository<PaytoAddress>(_collectionName).GetAllAsync()).ToList();

        public async Task<PaytoAddress?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<PaytoAddress>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(PaytoAddress entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.CreatedBy)) entity.CreatedBy = "System";
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = entity.CreatedBy;
            await _unitOfWork.Repository<PaytoAddress>(_collectionName).AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(string id, PaytoAddress entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = "System";
            await _unitOfWork.Repository<PaytoAddress>(_collectionName).UpdateAsync(id, entity);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _unitOfWork.Repository<PaytoAddress>(_collectionName).DeleteAsync(id);
            return true;
        }
    }
}
