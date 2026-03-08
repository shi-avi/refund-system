//using RefundSystemApi.Models.Entities;

//namespace RefundSystemApi.Repositories.Interfaces
//{
//    public interface ISystemBudgetRepository
//    {
//        Task<SystemBudget> GetCurrentBudgetAsync();
//    }
//}

using RefundSystemApi.Models.Entities;

namespace RefundSystemApi.Repositories.Interfaces
{
    public interface ISystemBudgetRepository
    {
        Task<SystemBudget?> GetCurrentBudget();
    }
}