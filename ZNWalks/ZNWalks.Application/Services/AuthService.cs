using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Application.DTOs.AuthDTOs;
using ZNWalks.Application.Interfaces;
using ZNWalks.Domain.Interfaces;
using ZNWalks.Infra.Identity.Domian.Interfaces;
using ZNWalks.Infra.Identity.Domian.Models;

namespace ZNWalks.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthUnitOfWork _unitOfWork;
        private readonly IConfiguration configuration;

        public AuthService(IAuthUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            this.configuration = configuration;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequestDto)
        {
            var user = await _unitOfWork.AuthRepository.FindByEmailAsync(loginRequestDto.Username);

            if (user == null)
            {
                return new LoginResponseDto
                {
                    Success = false,
                    Message = "User Not Found"
                };
            }

            var result = await _unitOfWork.AuthRepository.CheckPasswordAsync(user, loginRequestDto.Password);

            if (result == false)
            {
                return new LoginResponseDto
                {
                    Success = false,
                    Message = "Username or password inccorect!"
                };
            }

            var roles = await _unitOfWork.AuthRepository.GetUserRolesAsync(user);

            var claims = CreateClaims(user, roles);

            var token = CreateTokenString(claims);

            await _unitOfWork.TokenRepository.AddTokenAsync(new TokenStore
            {
                UserId = user.Id,
                Jti = claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value,
                ExpiryDate = DateTime.UtcNow.AddMinutes(15),
                Token = token,
                IsRevoked = false
            });

            return new LoginResponseDto
            {
                Success = true,
                Message = "Login successfully!",
                Token = token,
                UserId = user.Id
            };
        }

        public async Task LogoutAsync(string jti)
        {
            await _unitOfWork.TokenRepository.RevokeTokenAsync(jti);
        }

        public async Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto registerRequestDto)
        {
            using var transaction = await _unitOfWork.AuthRepository.BeginTransactionAsync();

            var user = new ApplicationUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username,
            };

            var result = await _unitOfWork.AuthRepository.CreateUserAsync(user, registerRequestDto.Password);

            if (!result.Succeeded)
            {
                return new RegisterResponseDto
                {
                    Success = false,
                    Message = string.Join(", ", result.Errors.Select(e => e.Description))
                };
            }

            if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
            {
                try
                {
                    result = await _unitOfWork.AuthRepository.AddUserToRolesAsync(user, registerRequestDto.Roles);
                }
                catch (Exception ex)
                {
                    await _unitOfWork.AuthRepository.DeleteUserAsync(user);
                    await transaction.RollbackAsync();
                    return new RegisterResponseDto
                    {
                        Success = false,
                        Message = string.Join(", ", result.Errors.Select(e => e.Description), ex.Message)
                    };
                }
            }
            await transaction.CommitAsync();
            return new RegisterResponseDto
            {
                Success = true,
                Message = "User created successfully",
                UserId = user.Id
            };
        }

        private IEnumerable<Claim> CreateClaims(ApplicationUser user, IEnumerable<string> roles)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email!));


            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }
        private string CreateTokenString(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]!));

            var credentails = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                 issuer: configuration["JWT:Issuer"]!,
                 audience: configuration["JWT:Audience"]!,
                 claims: claims,
                 expires: DateTime.UtcNow.AddMinutes(15),
                 signingCredentials: credentails);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
