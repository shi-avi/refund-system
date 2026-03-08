using Microsoft.AspNetCore.Mvc;
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
}
