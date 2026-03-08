//using RefundSystemApi.Models.DTO;
//using RefundSystemApi.Models.Entities;
//using RefundSystemApi.Repositories.Interfaces;
//using RefundSystemApi.Services.Interfaces;

//namespace RefundSystemApi.Services.Classes
//{
//    public class IncomeService : IIncomeService
//    {
//        private readonly IIncomeRepository _incomeRepository;

//        public IncomeService(IIncomeRepository incomeRepository)
//        {
//            _incomeRepository = incomeRepository;
//        }
//        public async Task<List<Income>> GetCitizenIncomesByYearAsync(int citizenId, int year)
//        {
//            return await _incomeRepository.GetCitizenIncomesByYearAsync(citizenId, year);
//        }

//        public async Task AddRangeAsync(List<Income> incomes)
//        {
//            if (incomes == null || !incomes.Any())
//                throw new ArgumentException("Income list cannot be empty");

//            await _incomeRepository.AddRangeAsync(incomes);
//        }
//    }
//}
using RefundSystemApi.Repositories.Interfaces;
using RefundSystemApi.Services.Interfaces;

namespace RefundSystemApi.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly IIncomeRepository _incomeRepository;

        public IncomeService(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        public async Task<List<object>> GetIncomeByCitizenGroupedByYear(int citizenId)
        {
            // בדיקה שמזהה אזרח תקין
            if (citizenId <= 0)
                throw new Exception("Citizen id must be greater than zero");

            var incomes = await _incomeRepository.GetIncomeByCitizenGroupedByYear(citizenId);

            // בדיקה שיש נתונים
            if (incomes == null || incomes.Count == 0)
                return new List<object>();

            return incomes;
        }
    }
}
