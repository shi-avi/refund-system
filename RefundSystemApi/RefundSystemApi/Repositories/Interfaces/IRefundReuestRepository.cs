//using RefundSystemApi.Models.DTO;
//using RefundSystemApi.Models.Entities;

//namespace RefundSystemApi.Repositories.Interfaces
//{
//    public interface IRefundRequestRepository
//    {
//        // מחזיר את כל הבקשות במצב Pending (למסך פקיד)
//        Task<List<PendingRequestDto>> GetPendingRequestsAsync();

//        // קריאה ל-Stored Procedure שמבצעת את כל הלוגיקה העסקית
//        Task<RefundCalculationResultDto> CalculateRefundAsync(int requestId, bool clerkDecision);

//        // שליפת היסטוריית בקשות של אזרח
//        Task<List<RefundRequest>> GetCitizenRequestsAsync(int citizenId);

//        // יצירת בקשה חדשה (במצב Pending)
//        Task<RefundRequest> CreateRefundRequestAsync(RefundRequest request);
//    }
//}


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