using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RefundSystemApi.Data;
using RefundSystemApi.Models.Entities;
using RefundSystemApi.Repositories.Interfaces;

namespace RefundSystemApi.Repositories
{
    public class RefundRequestRepository : IRefundRequestRepository
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction? _transaction;

        public RefundRequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task BeginTransaction()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        public async Task<List<RefundRequests>> GetPending()
        {
            return await _context.RefundRequests
                .Where(r => r.Status == "Pending")
                .ToListAsync();
        }

        public async Task<RefundRequests?> GetById(int id)
        {
            return await _context.RefundRequests
                .FirstOrDefaultAsync(r => r.RequestId == id);
        }

        public async Task<List<RefundRequests>> GetByCitizenId(int citizenId)
        {
            return await _context.RefundRequests
                .Where(r => r.CitizenId == citizenId)
                .ToListAsync();
        }

        public async Task<RefundRequests?> GetLastRequest(int citizenId)
        {
            return await _context.RefundRequests
                .Where(r => r.CitizenId == citizenId)
                .OrderByDescending(r => r.CreatedAt)
                .FirstOrDefaultAsync();
        }

        public async Task AddIncomes(List<Incomes> incomes)
        {
            _context.Incomes.AddRange(incomes);
            await _context.SaveChangesAsync();
        }

        public async Task<RefundRequests> CreateRefundRequest(RefundRequests request)
        {
            _context.RefundRequests.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<RefundAmountResult?> CalculateRefund(int citizenId, int year)
        {
            return (await _context.RefundAmountResult
                .FromSqlRaw("EXEC sp_CalculateRefundAmount @CitizenId = {0}, @Year = {1}", citizenId, year)
                .ToListAsync())
                .FirstOrDefault();
        }

        public async Task<ProcessRefundResult?> ProcessRefund(int requestId, bool decision)
        {
            return _context.ProcessRefundResult
                .FromSqlRaw("EXEC sp_ProcessRefundRequest @RequestId = {0}, @ClerkDecision = {1}",
                    requestId, decision)
                .AsEnumerable()
                .FirstOrDefault();
        }
    }
}