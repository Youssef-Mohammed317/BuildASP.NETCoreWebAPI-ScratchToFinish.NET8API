using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZNWalks.Application.DTOs.RegionDTOs;
using ZNWalks.Application.Interfaces;

namespace ZNWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionServices _regionServices;

        public RegionsController(IRegionServices regionServices)
        {
            _regionServices = regionServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = _regionServices.GetAll();

            return Ok(regions);
        }
        [HttpGet("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var region = _regionServices.GetById(id);

            return region == null ? NotFound() : Ok(region);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateRegionDto createRegionDto)
        {
            var region = _regionServices.Create(createRegionDto);

            return CreatedAtAction(nameof(GetById), new { Id = region.Id }, region);
        }
        [HttpPut("{id:guid}")]
        public IActionResult Update([FromRoute] Guid id, UpdateRegionDto updateRegionDto)
        {
            var region = _regionServices.Update(id, updateRegionDto);

            return Ok(region);
        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            _regionServices.DeleteById(id);

            return NoContent();
        }
    }
}
