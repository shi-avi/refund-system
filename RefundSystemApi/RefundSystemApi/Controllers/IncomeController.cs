using Microsoft.AspNetCore.Mvc;
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
}
