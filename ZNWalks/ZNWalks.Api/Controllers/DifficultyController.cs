﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ZNWalks.Api.CustomActionFilters;
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
        private readonly IDifficultyService difficultyService;

        public DifficultyController(IDifficultyService _difficultyService)
        {
            difficultyService = _difficultyService;
        }

        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            throw new Exception("My Exception");
            var difficulties = await difficultyService.GetAllAsync();
            return Ok(difficulties);
        }

        [HttpGet("{id:guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var difficulty = await difficultyService.GetByIdAsync(id);

            return difficulty == null ? NotFound() : Ok(difficulty);
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] CreateDifficultyDto createDifficulty)
        {
            var difficulty = await difficultyService.CreateAsync(createDifficulty);

            return difficulty == null ? NotFound() : CreatedAtAction(nameof(GetById), new { Id = difficulty.Id }, difficulty);
        }

        [HttpPut("{id:guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateDifficultyDto updateDifficultyDto)
        {
            var difficulty = await difficultyService.UpdateAsync(id, updateDifficultyDto);

            return difficulty == null ? NotFound() : Ok(difficulty);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var difficulty = await difficultyService.DeleteByIdAsync(id);

            return difficulty == null ? NotFound() : Ok(difficulty);
        }
    }
}
