using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Application.DTOs.AuthDTOs.LoginDTOs;
using ZNWalks.Application.DTOs.AuthDTOs.RegisterDTOs;

namespace ZNWalks.Application.Interfaces
{
    public interface IAuthService
    {
        Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto registerRequestDto);
        Task<LoginResponseDto> LoginAsync(LoginRequestDto loignRequestDto);
        Task LogoutAsync(string jti);
    }
}
