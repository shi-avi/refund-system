using RefundSystemApi.Models.Entities;

namespace RefundSystemApi.Services.Interfaces
{
    public interface ISystemBudgetService
    {
        Task<SystemBudget> GetCurrentBudget();
    }
}