using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Application.Interfaces;
using ZNWalks.Infra.Identity.Domian.Interfaces;
using ZNWalks.Infra.Identity.Domian.Models;

namespace ZNWalks.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IAuthUnitOfWork _unitOfWork;

        public TokenService(IAuthUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> IsTokenValidAsync(string jti)
        {
            return await _unitOfWork.TokenRepository.IsTokenValidAsync(jti);
        }
        public async Task AddTokenAsync(TokenStore token)
        {
            await _unitOfWork.TokenRepository.AddTokenAsync(token);
        }

        public async Task<TokenStore?> GetByJtiAsync(string jti)
        {
            var token = await _unitOfWork.TokenRepository.GetByJtiAsync(jti);
            return token;
        }

        public async Task RevokeTokenAsync(string jti)
        {
            await _unitOfWork.TokenRepository.RevokeTokenAsync(jti);
        }
    }
}
