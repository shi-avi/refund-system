using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RefundSystemApi.Data;
using RefundSystemApi.Models.DTO;
using RefundSystemApi.Models.Entities;
using RefundSystemApi.Services.Interfaces;

namespace RefundSystemApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RefundRequestController : ControllerBase

    {
        private readonly IRefundRequestService _service;

        public RefundRequestController(IRefundRequestService service)
        {
            _service = service;
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetPending()
        {
            return Ok(await _service.GetPending());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("citizen/{citizenId}")]
        public async Task<IActionResult> GetByCitizenId(int citizenId)
        {
            return Ok(await _service.GetByCitizenId(citizenId));
        }

        [HttpGet("citizen/{citizenId}/last")]
        public async Task<IActionResult> GetLastRequest(int citizenId)
        {
            var result = await _service.GetLastRequest(citizenId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRefundRequest(CreateRefundRequestDto dto)
        {
            return Ok(await _service.CreateRefundRequest(dto));
        }

        [HttpPost("calculate")]
        public async Task<IActionResult> CalculateRefund(CalculateRefundDto dto)
        {
            return Ok(await _service.CalculateRefund(dto));
        }

        [HttpPost("process")]
        public async Task<IActionResult> ProcessRefund(ProcessRefundDto dto)
        {
            return Ok(await _service.ProcessRefund(dto));
        }
    }

    //{
    //    private readonly AppDbContext _context;

    //    public RefundRequestController(AppDbContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: api/refundrequests/pending
    //    [HttpGet("pending")]
    //    public async Task<IActionResult> GetPending()
    //    {
    //        var requests = await _context.RefundRequests
    //            .Where(r => r.Status == "Pending")
    //            .ToListAsync();

    //        return Ok(requests);
    //    }

    //    // GET: api/refundrequests/5
    //    [HttpGet("{id}")]
    //    public async Task<IActionResult> GetById(int id)
    //    {
    //        var request = await _context.RefundRequests
    //            .FirstOrDefaultAsync(r => r.RequestId == id);

    //        if (request == null)
    //            return NotFound();

    //        return Ok(request);
    //    }

    //    // GET: api/refundrequests/citizen/5
    //    [HttpGet("citizen/{citizenId}")]
    //    public async Task<IActionResult> GetByCitizenId(int citizenId)
    //    {
    //        var requests = await _context.RefundRequests
    //            .Where(r => r.CitizenId == citizenId)
    //            .ToListAsync();

    //        return Ok(requests);
    //    }

    //    // GET: api/refundrequests/citizen/5/last
    //    [HttpGet("citizen/{citizenId}/last")]
    //    public async Task<IActionResult> GetLastRequest(int citizenId)
    //    {
    //        var request = await _context.RefundRequests
    //            .Where(r => r.CitizenId == citizenId)
    //            .OrderByDescending(r => r.CreatedAt)
    //            .FirstOrDefaultAsync();

    //        if (request == null)
    //            return NotFound();

    //        return Ok(request);
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> CreateRefundRequest([FromBody] CreateRefundRequestDto dto)
    //    {
    //        using var transaction = await _context.Database.BeginTransactionAsync();

    //        try
    //        {
    //            // 1️⃣ שמירת הכנסות
    //            var incomes = dto.Incomes.Select(i => new Incomes
    //            {
    //                CitizenId = dto.CitizenId,
    //                Year = dto.Year,
    //                Month = i.Month,
    //                Amount = i.Amount
    //            }).ToList();

    //            _context.Incomes.AddRange(incomes);
    //            await _context.SaveChangesAsync();


    //            // 2️⃣ יצירת בקשת החזר
    //            var request = new RefundRequests
    //            {
    //                CitizenId = dto.CitizenId,
    //                Year = dto.Year,
    //                Status = "Pending",
    //                CreatedAt = DateTime.UtcNow
    //            };

    //            _context.RefundRequests.Add(request);
    //            await _context.SaveChangesAsync();


    //            // 3️⃣ הפעלת פרוצדורת חישוב
    //            var result = (await _context.RefundAmountResult
    //                 .FromSqlRaw("EXEC sp_CalculateRefundAmount @CitizenId = {0}, @Year = {1}", dto.CitizenId, dto.Year)
    //                 .ToListAsync())
    //                 .FirstOrDefault();

    //            var refundAmount = result?.RefundAmount ?? 0;

    //            await transaction.CommitAsync();

    //            // 4️⃣ החזרת סכום זכאות
    //            return Ok(new
    //            {
    //                requestId = request.RequestId,
    //                estimatedRefund = result
    //            });
    //        }
    //        catch (Exception ex)
    //        {
    //            await transaction.RollbackAsync();
    //            return StatusCode(500, ex.Message);
    //        }
    //    }

    //    //POST /api/refund/calculate
    //    [HttpPost("calculate")]
    //    public async Task<IActionResult> CalculateRefund(CalculateRefundDto dto)
    //    {
    //        try
    //        {
    //            var result = _context.RefundAmountResult
    //        .FromSqlRaw("EXEC sp_CalculateRefundAmount @CitizenId = {0}, @Year = {1}",
    //            dto.CitizenId, dto.Year)
    //        .AsEnumerable()
    //        .FirstOrDefault();

    //        if (result == null)
    //            return BadRequest("Cannot calculate refund");

    //        return Ok(result);
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest(ex.Message);
    //        }
    //    }

    //    //POST /api/refund/process
    //    [HttpPost("process")]
    //    public async Task<IActionResult> ProcessRefund(ProcessRefundDto dto)
    //    {
    //        var result = _context.ProcessRefundResult
    //        .FromSqlRaw("EXEC sp_ProcessRefundRequest @RequestId = {0}, @ClerkDecision = {1}",
    //            dto.RequestId, dto.ClerkDecision)
    //        .AsEnumerable()
    //        .FirstOrDefault();

    //        return Ok(result);
    //    }

    //}
}
