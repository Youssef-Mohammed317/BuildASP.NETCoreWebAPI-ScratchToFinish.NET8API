using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZNWalks.Application.DTOs.DifficultyDTOs;
using ZNWalks.Application.DTOs.RegionDTOs;
using ZNWalks.Application.Interfaces;
using ZNWalks.Application.Services;
using ZNWalks.Domain.Models;

namespace ZNWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifficultyController : ControllerBase
    {
        private readonly IDifficultyService _difficultyService;

        public DifficultyController(IDifficultyService difficultyService)
        {
            _difficultyService = difficultyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var difficulties = await _difficultyService.GetAllAsync();

            return Ok(difficulties);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var difficulty = await _difficultyService.GetByIdAsync(id);

            return difficulty == null ? NotFound() : Ok(difficulty);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDifficultyDto createDifficulty)
        {
            var difficulty = await _difficultyService.CreateAsync(createDifficulty);

            return difficulty == null ? NotFound() : CreatedAtAction(nameof(GetById), new { Id = difficulty.Id }, difficulty);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateDifficultyDto updateDifficultyDto)
        {
            var difficulty = await _difficultyService.UpdateAsync(id, updateDifficultyDto);

            return difficulty == null ? NotFound() : Ok(difficulty);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var difficulty = await _difficultyService.DeleteByIdAsync(id);

            return difficulty == null ? NotFound() : Ok(difficulty);
        }
    }
}
