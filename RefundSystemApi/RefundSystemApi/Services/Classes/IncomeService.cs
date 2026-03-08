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
