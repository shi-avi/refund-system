using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RefundSystemApi.Data;
using RefundSystemApi.Services.Interfaces;

namespace RefundSystemApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemBudgetController : ControllerBase
    //{
    //    private readonly AppDbContext _context;

    //    public SystemBudgetController(AppDbContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: api/systembudget
    //    [HttpGet]
    //    public async Task<IActionResult> GetCurrent()
    //    {
    //        var budget = await _context.SystemBudget.FirstOrDefaultAsync();
    //        return Ok(budget);
    //    }
    //}

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
