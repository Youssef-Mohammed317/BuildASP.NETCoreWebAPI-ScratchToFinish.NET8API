using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZNWalks.Application.DTOs.RegionDTOs;
using ZNWalks.Application.Interfaces;

namespace ZNWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionServices;

        public RegionController(IRegionService regionServices)
        {
            _regionServices = regionServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await _regionServices.GetAllAsync();

            return Ok(regions);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var region = await _regionServices.GetByIdAsync(id);

            return region == null ? NotFound() : Ok(region);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRegionDto createRegionDto)
        {
            var region = await _regionServices.CreateAsync(createRegionDto);
            return region == null ? NotFound() : CreatedAtAction(nameof(GetById), new { Id = region.Id }, region);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionDto updateRegionDto)
        {
            var region = await _regionServices.UpdateAsync(id, updateRegionDto);

            return region == null ? NotFound() : Ok(region);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var region = await _regionServices.DeleteByIdAsync(id);

            return region == null ? NotFound() : Ok(region);
        }
    }
}
