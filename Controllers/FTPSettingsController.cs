using Microsoft.AspNetCore.Mvc;
using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Services;

namespace PemrClearingHouse.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FTPSettingsController : ControllerBase
    {
        private readonly FTPSettingsService _service;

        public FTPSettingsController(FTPSettingsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<FTPSettings>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FTPSettings>> GetById(string id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(FTPSettings entity)
        {
            await _service.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, FTPSettings entity)
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