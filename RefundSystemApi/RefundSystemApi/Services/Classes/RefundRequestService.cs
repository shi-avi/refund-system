using RefundSystemApi.Models.DTO;
using RefundSystemApi.Models.Entities;
using RefundSystemApi.Repositories.Interfaces;
using RefundSystemApi.Services.Interfaces;

namespace RefundSystemApi.Services
{
    public class RefundRequestService : IRefundRequestService
    {
        private readonly IRefundRequestRepository _repo;

        public RefundRequestService(IRefundRequestRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<RefundRequests>> GetPending()
        {
            return await _repo.GetPending();
        }

        public async Task<RefundRequests?> GetById(int id)
        {
            if (id <= 0)
                throw new Exception("Invalid request id");

            return await _repo.GetById(id);
        }

        public async Task<List<RefundRequests>> GetByCitizenId(int citizenId)
        {
            if (citizenId <= 0)
                throw new Exception("Invalid citizen id");

            return await _repo.GetByCitizenId(citizenId);
        }

        public async Task<RefundRequests?> GetLastRequest(int citizenId)
        {
            if (citizenId <= 0)
                throw new Exception("Invalid citizen id");

            return await _repo.GetLastRequest(citizenId);
        }

        public async Task<object> CreateRefundRequest(CreateRefundRequestDto dto)
        {
            if (dto.CitizenId <= 0)
                throw new Exception("CitizenId is invalid");

            if (dto.Incomes == null || !dto.Incomes.Any())
                throw new Exception("Income list cannot be empty");

            var lastRequest = await _repo.GetLastRequest(dto.CitizenId);

            if (lastRequest != null && lastRequest.Year == dto.Year)
                throw new Exception("Refund request already exists for this year");

            await _repo.BeginTransaction();

            try
            {
                var incomes = dto.Incomes.Select(i => new Incomes
                {
                    CitizenId = dto.CitizenId,
                    Year = dto.Year,
                    Month = i.Month,
                    Amount = i.Amount
                }).ToList();

                await _repo.AddIncomes(incomes);

                var request = new RefundRequests
                {
                    CitizenId = dto.CitizenId,
                    Year = dto.Year,
                    Status = "Pending",
                    CreatedAt = DateTime.UtcNow
                };

                var createdRequest = await _repo.CreateRefundRequest(request);

                var result = await _repo.CalculateRefund(dto.CitizenId, dto.Year);

                await _repo.Commit();

                return new
                {
                    requestId = createdRequest.RequestId,
                    estimatedRefund = result
                };
            }
            catch
            {
                await _repo.Rollback();
                throw;
            }
        }

        public async Task<RefundAmountResult?> CalculateRefund(CalculateRefundDto dto)
        {
            if (dto.CitizenId <= 0)
                throw new Exception("Invalid citizen id");

            return await _repo.CalculateRefund(dto.CitizenId, dto.Year);
        }

        public async Task<ProcessRefundResult?> ProcessRefund(ProcessRefundDto dto)
        {
            if (dto.RequestId <= 0)
                throw new Exception("Invalid request id");

            return await _repo.ProcessRefund(dto.RequestId, dto.ClerkDecision);
        }
    }
}
