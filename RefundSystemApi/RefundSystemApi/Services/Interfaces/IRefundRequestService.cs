//using RefundSystemApi.Models.DTO;
//using RefundSystemApi.Models.Entities;

//namespace RefundSystemApi.Services.Interfaces
//{
//    public interface IRefundRequestService
//    {
//        Task<List<PendingRequestDto>> GetPendingRequestsAsync();

//        Task<RefundCalculationResultDto> CalculateRefundAsync(int requestId, bool clerkDecision);

//        Task<RefundRequest> CreateRefundRequestAsync(CreateRefundRequestDto dto);
//    }
//}


using RefundSystemApi.Models.DTO;
using RefundSystemApi.Models.Entities;

namespace RefundSystemApi.Services.Interfaces
{
    public interface IRefundRequestService
    {
        Task<List<RefundRequests>> GetPending();
        Task<RefundRequests?> GetById(int id);
        Task<List<RefundRequests>> GetByCitizenId(int citizenId);
        Task<RefundRequests?> GetLastRequest(int citizenId);

        Task<object> CreateRefundRequest(CreateRefundRequestDto dto);

        Task<RefundAmountResult?> CalculateRefund(CalculateRefundDto dto);

        Task<ProcessRefundResult?> ProcessRefund(ProcessRefundDto dto);
    }
}