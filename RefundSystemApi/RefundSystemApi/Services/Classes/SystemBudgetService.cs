//using RefundSystemApi.Repositories.Interfaces;
//using RefundSystemApi.Services.Interfaces;

//namespace RefundSystemApi.Services.Classes
//{
//    public class SystemBudgetService : ISystemBudgetService
//    {
//        private readonly ISystemBudgetRepository _systemBudgetRepository;
//        public SystemBudgetService(ISystemBudgetRepository systemBudgetRepository)
//        {
//            _systemBudgetRepository = systemBudgetRepository;
//        }

//        public async Task<decimal> GetCurrentBudgetAmountAsync()
//        {
//            var budget = await _systemBudgetRepository.GetCurrentBudgetAsync();
//            return budget?.CurrentAmount ?? 0;
//        }
//    }
//}

using RefundSystemApi.Models.Entities;
using RefundSystemApi.Repositories.Interfaces;
using RefundSystemApi.Services.Interfaces;

namespace RefundSystemApi.Services
{
    public class SystemBudgetService : ISystemBudgetService
    {
        private readonly ISystemBudgetRepository _repository;

        public SystemBudgetService(ISystemBudgetRepository repository)
        {
            _repository = repository;
        }

        public async Task<SystemBudget> GetCurrentBudget()
        {
            var budget = await _repository.GetCurrentBudget();

            // בדיקה אם אין תקציב במערכת
            if (budget == null)
                throw new Exception("System budget not found");

            // בדיקה שהתקציב לא שלילי
            if (budget.CurrentAmount < 0)
                throw new Exception("System budget is invalid");

            // בדיקה שהתקציב לא אפס
            if (budget.CurrentAmount == 0)
                throw new Exception("System budget is empty");

            return budget;
        }
    }
}