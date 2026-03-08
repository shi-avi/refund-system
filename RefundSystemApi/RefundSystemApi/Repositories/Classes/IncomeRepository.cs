//using RefundSystemApi.Data;
//using RefundSystemApi.Models.Entities;
//using RefundSystemApi.Repositories.Interfaces;
//using Microsoft.EntityFrameworkCore;

//namespace RefundSystemApi.Repositories.Classes
//{
//    public class IncomeRepository : IIncomeRepository
//    {
//        private readonly AppDbContext _context;

//        public IncomeRepository(AppDbContext context) 
//        {
//            _context = context;
//        }

//        public async Task<List<Income>> GetCitizenIncomesByYearAsync(int citizenId, int year)
//        {
//            return await _context.Incomes
//                .Where(i => i.CitizenId == citizenId && i.Year == year)
//                .ToListAsync();
//        }

//        public async Task AddRangeAsync(List<Income> incomes)
//        {
//            await _context.Incomes.AddRangeAsync(incomes);
//            await _context.SaveChangesAsync();
//        }
//    }
//}
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
