﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Infra.Identity.Domian.Models;

namespace ZNWalks.Application.Interfaces
{
    public interface ITokenService
    {
        public Task<bool> IsTokenValidAsync(string jti);
        public Task AddTokenAsync(TokenStore token);

        public Task<TokenStore?> GetByJtiAsync(string jti);

        public Task RevokeTokenAsync(string jti);
    }
}
