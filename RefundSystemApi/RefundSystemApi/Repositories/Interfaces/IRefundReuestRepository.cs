using RefundSystemApi.Models.Entities;

namespace RefundSystemApi.Repositories.Interfaces
{
    public interface IRefundRequestRepository
    {
        Task<List<RefundRequests>> GetPending();
        Task<RefundRequests?> GetById(int id);
        Task<List<RefundRequests>> GetByCitizenId(int citizenId);
        Task<RefundRequests?> GetLastRequest(int citizenId);

        Task AddIncomes(List<Incomes> incomes);
        Task<RefundRequests> CreateRefundRequest(RefundRequests request);

        Task<RefundAmountResult?> CalculateRefund(int citizenId, int year);
        Task<ProcessRefundResult?> ProcessRefund(int requestId, bool decision);

        Task BeginTransaction();
        Task Commit();
        Task Rollback();
    }
}