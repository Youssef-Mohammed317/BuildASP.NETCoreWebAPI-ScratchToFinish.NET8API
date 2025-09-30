using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Threading.Tasks;
using ZNWalks.Api.CustomActionFilters;
using ZNWalks.Application.DTOs.Common.Filtering;
using ZNWalks.Application.DTOs.Common.Paginate;
using ZNWalks.Application.DTOs.Common.Sorting;
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
        public async Task<IActionResult> GetAll(
            [FromQuery] FilterParam? filterParam = null,
            [FromQuery] SortParam? sortParam = null,
            [FromQuery] PaginateParam? paginateParam = null)
        {
            var walks = await _walkService.GetAllAsync(
                filterParam,
                sortParam,
                paginateParam);

            return Ok(walks);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] GetAllRequestDto requestDto)
        {
            var walks = await _walkService.SearchWalkAsync(requestDto);

            return Ok(walks);
        }
        [HttpPost("search/details")]
        public async Task<IActionResult> SearchWithDetails([FromBody] GetAllRequestDto requestDto)
        {
            var walks = await _walkService.SearchWalkWithDetailsAsync(requestDto);

            return Ok(walks);
        }


        [HttpGet]
        [Route("details")]
        public async Task<IActionResult> GetAllWithDetails(
            [FromQuery] FilterParam? filterParam = null,
            [FromQuery] SortParam? sortParam = null,
            [FromQuery] PaginateParam? paginateParam = null)
        {
            var walks = await _walkService.GetAllWithDetailsAsync(
                filterParam,
                sortParam,
                paginateParam);

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
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkDto walkDto)
        {
            var walk = await _walkService.UpdateAsync(id, walkDto);

            return walk == null ? NotFound() : Ok(walk);
        }
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] CreateWalkDto walkDto)
        {
            var walk = await _walkService.CreateAsync(walkDto);
            return walk == null ? NotFound() : Ok(walk);
        }

    }
}
