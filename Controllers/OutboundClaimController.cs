using Microsoft.AspNetCore.Mvc;
using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Services;

namespace PemrClearingHouse.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OutboundClaimController : ControllerBase
    {
        private readonly OutboundClaimService _service;

        public OutboundClaimController(OutboundClaimService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<OutboundClaim>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OutboundClaim>> GetById(string id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(OutboundClaim entity)
        {
            await _service.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id}, entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, OutboundClaim entity)
        {
            await _service.UpdateAsync(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
} 