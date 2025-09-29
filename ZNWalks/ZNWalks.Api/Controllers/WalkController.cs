using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZNWalks.Application.DTOs.WalkDTOs;
using ZNWalks.Application.Interfaces;

namespace ZNWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly IWalkService _walkService;

        public WalkController(IWalkService walkService)
        {
            _walkService = walkService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walks = await _walkService.GetAllAsync();

            return Ok(walks);
        }
        [HttpGet]
        [Route("WithDetails")]
        public async Task<IActionResult> GetAllWithDetails()
        {
            var walks = await _walkService.GetAllWithDetailsAsync();

            return Ok(walks);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walk = await _walkService.GetByIdAsync(id);

            return walk == null ? NotFound() : Ok(walk);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var walk = await _walkService.DeleteByIdAsync(id);

            return walk == null ? NotFound() : Ok(walk);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkDto walkDto)
        {
            var walk = await _walkService.UpdateAsync(id, walkDto);

            return walk == null ? NotFound() : Ok(walk);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWalkDto walkDto)
        {
            var walk = await _walkService.CreateAsync(walkDto);
            return walk == null ? NotFound() : Ok(walk);
        }

    }
}
