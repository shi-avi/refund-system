using Microsoft.EntityFrameworkCore;
using RefundSystemApi.Data;
using RefundSystemApi.Repositories.Interfaces;

namespace RefundSystemApi.Repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly AppDbContext _context;

        public IncomeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<object>> GetIncomeByCitizenGroupedByYear(int citizenId)
        {
            return await _context.Incomes
                .Where(i => i.CitizenId == citizenId)
                .GroupBy(i => i.Year)
                .Select(g => new
                {
                    Year = g.Key,
                    TotalIncome = g.Sum(x => x.Amount)
                })
                .OrderBy(x => x.Year)
                .Cast<object>()
                .ToListAsync();
        }
    }
}
