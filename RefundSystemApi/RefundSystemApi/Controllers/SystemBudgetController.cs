using Microsoft.AspNetCore.Mvc;
using RefundSystemApi.Services.Interfaces;

namespace RefundSystemApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemBudgetController : ControllerBase
    {
        private readonly ISystemBudgetService _service;

        public SystemBudgetController(ISystemBudgetService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrent()
        {
            var budget = await _service.GetCurrentBudget();
            return Ok(budget);
        }
    }
}
