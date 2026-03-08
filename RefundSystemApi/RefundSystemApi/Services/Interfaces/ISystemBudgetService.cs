//namespace RefundSystemApi.Services.Interfaces
//{
//    public interface ISystemBudgetService
//    {
//        Task<decimal> GetCurrentBudgetAmountAsync();
//    }
//}

using RefundSystemApi.Models.Entities;

namespace RefundSystemApi.Services.Interfaces
{
    public interface ISystemBudgetService
    {
        Task<SystemBudget> GetCurrentBudget();
    }
}