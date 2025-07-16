using Microsoft.AspNetCore.Mvc;
using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Services;

namespace PemrClearingHouse.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaimStatusController : ControllerBase
    {
        private readonly ClaimStatusService _service;

        public ClaimStatusController(ClaimStatusService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClaimStatus>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClaimStatus>> GetById(string id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ClaimStatus entity)
        {
            await _service.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, ClaimStatus entity)
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