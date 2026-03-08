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