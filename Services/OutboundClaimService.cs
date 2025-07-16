using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class OutboundClaimService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "OutboundClaims";

        public OutboundClaimService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<OutboundClaim>> GetAllAsync()
            => (await _unitOfWork.Repository<OutboundClaim>(_collectionName).GetAllAsync()).ToList();

        public async Task<OutboundClaim?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<OutboundClaim>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(OutboundClaim entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.CreatedBy)) entity.CreatedBy = "System";
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = entity.CreatedBy;
            await _unitOfWork.Repository<OutboundClaim>(_collectionName).AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(string id, OutboundClaim entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = "System";
            await _unitOfWork.Repository<OutboundClaim>(_collectionName).UpdateAsync(id, entity);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _unitOfWork.Repository<OutboundClaim>(_collectionName).DeleteAsync(id);
            return true;
        }
    }
} 