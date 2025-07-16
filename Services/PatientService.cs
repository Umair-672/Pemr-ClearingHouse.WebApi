using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Repositories.UnitOfWork;
using Repositories;

namespace PemrClearingHouse.Api.Services
{
    public class PatientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _collectionName = "Patients";

        public PatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Patient>> GetAllAsync()
            => (await _unitOfWork.Repository<Patient>(_collectionName).GetAllAsync()).ToList();

        public async Task<Patient?> GetByIdAsync(string id)
            => await _unitOfWork.Repository<Patient>(_collectionName).GetByIdAsync(id);

        public async Task AddAsync(Patient entity)
            => await _unitOfWork.Repository<Patient>(_collectionName).AddAsync(entity);

        public async Task UpdateAsync(string id, Patient entity)
            => await _unitOfWork.Repository<Patient>(_collectionName).UpdateAsync(id, entity);

        public async Task DeleteAsync(string id)
            => await _unitOfWork.Repository<Patient>(_collectionName).DeleteAsync(id);
    }
} 