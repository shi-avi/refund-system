//using Microsoft.EntityFrameworkCore;
//using RefundSystemApi.Data;
//using RefundSystemApi.Models.Entities;
//using RefundSystemApi.Repositories.Interfaces;

//namespace RefundSystemApi.Repositories.Classes
//{
//    public class CitizenRepository : ICitizenRepository
//    {
//        private readonly AppDbContext _context;
//        public CitizenRepository(AppDbContext context) 
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<Citizen>> GetAllCitizens()
//        {
//            return await _context.Citizen.ToListAsync();
//        }
//        public async Task<Citizen?> GetCitizenById(int CitizenId)
//        {
//            return await _context.Citizen.FindAsync(CitizenId);
//        }
//        public async Task<Citizen> AddCitizen(Citizen Citizen)
//        {
//            _context.Citizen.Add(Citizen);
//            await _context.SaveChangesAsync();
//            return Citizen;
//        }
//        public async Task UpdateCitizen(Citizen Citizen)
//        {
//            _context.Citizen.Update(Citizen);
//            await _context.SaveChangesAsync();
//        }
//        public async Task DeleteCitizen(Citizen Citizen)
//        {
//            _context.Citizen.Remove(Citizen);
//            await _context.SaveChangesAsync();
//        }
//        public async Task<Citizen> GetByIdentityAsync(string identityNumber)
//        {
//            return await _context.Citizen
//                .Include(c => c.RefundRequests)
//                .FirstOrDefaultAsync(c => c.IdentityCitizen == identityNumber);
//        }

//        public async Task<Citizen> GetByIdAsync(int id)
//        {
//            return await _context.Citizen
//                .Include(c => c.RefundRequests)
//                .FirstOrDefaultAsync(c => c.CitizenId == id);
//        }
//    }
//}

using Microsoft.EntityFrameworkCore;
using RefundSystemApi.Data;
using RefundSystemApi.Models.Entities;
using RefundSystemApi.Repositories.Interfaces;

namespace RefundSystemApi.Repositories
{
    public class CitizenRepository : ICitizenRepository
    {
        private readonly AppDbContext _context;

        public CitizenRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Citizens?> GetByIdAsync(int id)
        {
            return await _context.Citizens.FindAsync(id);
        }

        public async Task<object?> GetCitizenByIdentityAsync(string identityCitizen)
        {
            return await _context.Citizens
                .Where(c => c.IdentityCitizen == identityCitizen)
                .Select(c => new
                {
                    citizenId = c.CitizenId,
                    identityCitizen = c.IdentityCitizen,
                    fullName = c.FullName
                })
                .FirstOrDefaultAsync();
        }

        public async Task<Citizens> CreateCitizenAsync(Citizens citizen)
        {
            _context.Citizens.Add(citizen);
            await _context.SaveChangesAsync();

            return citizen;
        }
    }
}