using Microsoft.AspNetCore.Mvc;
using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Services;

namespace PemrClearingHouse.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RTTransactionSettingsController : ControllerBase
    {
        private readonly RTTransactionSettingsService _service;

        public RTTransactionSettingsController(RTTransactionSettingsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<RTTransactionSettings>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RTTransactionSettings>> GetById(string id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(RTTransactionSettings entity)
        {
            await _service.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id}, entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, RTTransactionSettings entity)
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