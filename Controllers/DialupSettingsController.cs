using Microsoft.AspNetCore.Mvc;
using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Services;

namespace PemrClearingHouse.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DialupSettingsController : ControllerBase
    {
        private readonly DialupSettingsService _service;

        public DialupSettingsController(DialupSettingsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<DialupSettings>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DialupSettings>> GetById(string id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(DialupSettings settings)
        {
            await _service.AddAsync(settings);
            return CreatedAtAction(nameof(GetById), new { id = settings.Id }, settings);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, DialupSettings settings)
        {
            await _service.UpdateAsync(id, settings);
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