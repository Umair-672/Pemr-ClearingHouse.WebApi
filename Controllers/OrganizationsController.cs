using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PemrClearingHouse.Api.Entities;
using PemrClearingHouse.Api.Services;

namespace PemrClearingHouse.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrganizationsController : ControllerBase
    {
        private readonly OrganizationService _service;

        public OrganizationsController(OrganizationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var org = await _service.GetByIdAsync(id);
            return org == null ? NotFound() : Ok(org);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Organization org)
        {
            await _service.CreateAsync(org);
            return CreatedAtAction(nameof(Get), new { id = org.Id }, org);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Organization org)
        {
            var updated = await _service.UpdateAsync(id, org);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
