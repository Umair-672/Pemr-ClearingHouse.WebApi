 using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class OutboundClaimFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "OutboundClaimFiles";

        public OutboundClaimFileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<OutboundClaimFile>> GetAllAsync()
            => (await _unitOfWork.Repository<OutboundClaimFile>(_collectionName).GetAllAsync()).ToList();

        public async Task<OutboundClaimFile?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<OutboundClaimFile>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(OutboundClaimFile entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.CreatedBy)) entity.CreatedBy = "System";
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = entity.CreatedBy;
            await _unitOfWork.Repository<OutboundClaimFile>(_collectionName).AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(string id, OutboundClaimFile entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = "System";
            await _unitOfWork.Repository<OutboundClaimFile>(_collectionName).UpdateAsync(id, entity);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _unitOfWork.Repository<OutboundClaimFile>(_collectionName).DeleteAsync(id);
            return true;
        }
    }
}
