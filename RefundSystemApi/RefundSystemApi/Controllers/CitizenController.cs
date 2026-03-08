using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RefundSystemApi.Data;
using RefundSystemApi.Models.Entities;
using RefundSystemApi.Services.Interfaces;

namespace RefundSystemApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitizenController : ControllerBase
    {
        private readonly ICitizenService _citizenService;

        public CitizenController(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var citizen = await _citizenService.GetByIdAsync(id);

            if (citizen == null)
                return NotFound();

            return Ok(citizen);
        }

        [HttpGet("identity/{identityCitizen}")]
        public async Task<IActionResult> GetCitizenByIdentity(string identityCitizen)
        {
            var citizen = await _citizenService.GetCitizenByIdentityAsync(identityCitizen);

            if (citizen == null)
                return NotFound();

            return Ok(citizen);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCitizen([FromBody] Citizens citizen)
        {
            var result = await _citizenService.CreateCitizenAsync(citizen);

            return Ok(result);
        }
    }

    //{
    //    private readonly AppDbContext _context;

    //    public CitizenController(AppDbContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: api/citizens/5
    //    [HttpGet("{id}")]
    //    public async Task<IActionResult> GetById(int id)
    //    {
    //        var citizen = await _context.Citizens.FindAsync(id);

    //        if (citizen == null)
    //            return NotFound();

    //        return Ok(citizen);
    //    }

    //    [HttpGet("identity/{identityCitizen}")]
    //    public IActionResult GetCitizenByIdentity(string identityCitizen)
    //    {
    //        var citizen = _context.Citizens
    //            .Where(c => c.IdentityCitizen == identityCitizen)
    //            .Select(c => new
    //            {
    //                citizenId = c.CitizenId,
    //                identityCitizen = c.IdentityCitizen,
    //                fullName = c.FullName
    //            })
    //            .FirstOrDefault();

    //        if (citizen == null)
    //            return NotFound();

    //        return Ok(citizen);
    //    }

    //    // POST: api/citizens
    //    [HttpPost]
    //    public async Task<IActionResult> CreateCitizen([FromBody] Citizens citizen)
    //    {
    //        if (citizen == null)
    //            return BadRequest();

    //        _context.Citizens.Add(citizen);
    //        await _context.SaveChangesAsync();

    //        return Ok(citizen);
    //    }

    //}
}
