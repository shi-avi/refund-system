using RefundSystemApi.Models.Entities;
using RefundSystemApi.Repositories.Interfaces;
using RefundSystemApi.Services.Interfaces;

namespace RefundSystemApi.Services
{
    public class CitizenService : ICitizenService
    {
        private readonly ICitizenRepository _repository;

        public CitizenService(ICitizenRepository repository)
        {
            _repository = repository;
        }

        public async Task<Citizens?> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new Exception("Invalid citizen id");

            return await _repository.GetByIdAsync(id);
        }

        public async Task<object?> GetCitizenByIdentityAsync(string identityCitizen)
        {
            if (string.IsNullOrWhiteSpace(identityCitizen))
                throw new Exception("Identity is required");

            if (identityCitizen.Length != 9)
                throw new Exception("Identity must contain 9 digits");

            return await _repository.GetCitizenByIdentityAsync(identityCitizen);
        }

        public async Task<Citizens> CreateCitizenAsync(Citizens citizen)
        {
            if (citizen == null)
                throw new Exception("Citizen data is required");

            if (string.IsNullOrWhiteSpace(citizen.FullName))
                throw new Exception("Full name is required");

            if (string.IsNullOrWhiteSpace(citizen.IdentityCitizen))
                throw new Exception("Identity is required");

            if (citizen.IdentityCitizen.Length != 9)
                throw new Exception("Identity must contain 9 digits");

            var existingCitizen = await _repository.GetCitizenByIdentityAsync(citizen.IdentityCitizen);

            if (existingCitizen != null)
                throw new Exception("Citizen with this identity already exists");

            return await _repository.CreateCitizenAsync(citizen);
        }
    }
}
