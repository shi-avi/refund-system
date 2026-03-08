using RefundSystemApi.Models.Entities;

namespace RefundSystemApi.Repositories.Interfaces
{
    public interface ISystemBudgetRepository
    {
        Task<SystemBudget?> GetCurrentBudget();
    }
}