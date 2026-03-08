using Microsoft.AspNetCore.Mvc;
using RefundSystemApi.Models.DTO;
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
}
