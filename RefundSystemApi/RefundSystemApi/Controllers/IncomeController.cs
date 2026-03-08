using Microsoft.AspNetCore.Mvc;
using RefundSystemApi.Data;
using Microsoft.EntityFrameworkCore;
using RefundSystemApi.Models.DTO;
using RefundSystemApi.Models.Entities;
using RefundSystemApi.Services.Interfaces;

namespace RefundSystemApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeService _incomeService;

        public IncomeController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        [HttpGet("citizen/{citizenId}/by-year")]
        public async Task<IActionResult> GetIncomeByCitizenGroupedByYear(int citizenId)
        {
            var result = await _incomeService.GetIncomeByCitizenGroupedByYear(citizenId);

            if (result == null || !result.Any())
                return NotFound("No incomes found for this citizen");

            return Ok(result);
        }
    }

    //{
    //    private readonly AppDbContext _context;

    //    public IncomeController(AppDbContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: api/incomes/citizen/5/by-year
    //    [HttpGet("citizen/{citizenId}/by-year")]
    //    public async Task<IActionResult> GetIncomeByCitizenGroupedByYear(int citizenId)
    //    {
    //        var incomes = await _context.Incomes
    //            .Where(i => i.CitizenId == citizenId)
    //            .GroupBy(i => i.Year)
    //            .Select(g => new
    //            {
    //                Year = g.Key,
    //                TotalIncome = g.Sum(x => x.Amount)
    //            })
    //            .OrderBy(x => x.Year)
    //            .ToListAsync();

    //        return Ok(incomes);
    //    }
    //}
}
