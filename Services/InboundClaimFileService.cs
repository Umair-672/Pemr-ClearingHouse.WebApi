using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class InboundClaimFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "InboundClaimFiles";

        public InboundClaimFileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<InboundClaimFile>> GetAllAsync()
            => (await _unitOfWork.Repository<InboundClaimFile>(_collectionName).GetAllAsync()).ToList();

        public async Task<InboundClaimFile?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<InboundClaimFile>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(InboundClaimFile entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.CreatedBy)) entity.CreatedBy = "System";
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = entity.CreatedBy;
            await _unitOfWork.Repository<InboundClaimFile>(_collectionName).AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(string id, InboundClaimFile entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(entity.UpdatedBy)) entity.UpdatedBy = "System";
            await _unitOfWork.Repository<InboundClaimFile>(_collectionName).UpdateAsync(id, entity);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _unitOfWork.Repository<InboundClaimFile>(_collectionName).DeleteAsync(id);
            return true;
        }
    }
} 