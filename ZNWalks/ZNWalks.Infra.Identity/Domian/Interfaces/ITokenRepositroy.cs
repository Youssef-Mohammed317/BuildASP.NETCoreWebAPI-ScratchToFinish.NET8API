using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Infra.Identity.Domian.Models;

namespace ZNWalks.Infra.Identity.Domian.Interfaces
{
    public interface ITokenRepository
    {
        Task AddTokenAsync(TokenStore token);
        Task<TokenStore?> GetByJtiAsync(string jti);
        Task RevokeTokenAsync(string jti);
        public Task<bool> IsTokenValidAsync(string jti);
    }
}
