using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using ZNWalks.Api.CustomActionFilters;
using ZNWalks.Application.DTOs.AuthDTOs;
using ZNWalks.Application.Interfaces;

namespace ZNWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        [ValidateModel]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var result = await _authService.RegisterAsync(registerRequestDto);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Login")]
        [ValidateModel]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var result = await _authService.LoginAsync(loginRequestDto);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("Logout")]
        [ValidateModel]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var jti = User.FindFirstValue(JwtRegisteredClaimNames.Jti);

            if (string.IsNullOrEmpty(jti))
                return BadRequest("Invalid token.");

            await _authService.LogoutAsync(jti);

            return Ok(new { message = "User logged out successfully." });
        }

    }
}
