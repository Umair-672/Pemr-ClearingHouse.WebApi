using Microsoft.Extensions.Options;
using PemrClearingHouse.Api.Configurations;
using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class OrganizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName;

        public OrganizationService(IUnitOfWork unitOfWork, IOptions<MongoDBSettings> settings)
        {
            _unitOfWork = unitOfWork;
            _collectionName = settings.Value.CollectionName;
        }

        public async Task<List<Organization>> GetAsync() =>
            (await _unitOfWork.Repository<Organization>(_collectionName).GetAllAsync()).ToList();

        public async Task<Organization?> GetByIdAsync(string id) =>
            await _unitOfWork.Repository<Organization>(_collectionName).GetByIdAsync(id);

        public async Task CreateAsync(Organization org)
        {
            org.CreatedAt = DateTime.UtcNow;
            org.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(org.CreatedBy)) org.CreatedBy = "system";
            if (string.IsNullOrEmpty(org.UpdatedBy)) org.UpdatedBy = org.CreatedBy;
            await _unitOfWork.Repository<Organization>(_collectionName).AddAsync(org);
        }

        public async Task<bool> UpdateAsync(string id, Organization org)
        {
            org.UpdatedAt = DateTime.UtcNow;
            if (string.IsNullOrEmpty(org.UpdatedBy)) org.UpdatedBy = "system";
            await _unitOfWork.Repository<Organization>(_collectionName).UpdateAsync(id, org);
            return true; // Optionally, check for update result if needed
        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _unitOfWork.Repository<Organization>(_collectionName).DeleteAsync(id);
            return true; // Optionally, check for delete result if needed
        }
    }
}
