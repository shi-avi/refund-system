using Microsoft.EntityFrameworkCore;
using RefundSystemApi.Data;
using RefundSystemApi.Models.Entities;
using RefundSystemApi.Repositories.Interfaces;

namespace RefundSystemApi.Repositories
{
    public class SystemBudgetRepository : ISystemBudgetRepository
    {
        private readonly AppDbContext _context;

        public SystemBudgetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SystemBudget?> GetCurrentBudget()
        {
            return await _context.SystemBudget.FirstOrDefaultAsync();
        }
    }
}