using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Infra.Identity.Context;
using ZNWalks.Infra.Identity.Domian.Interfaces;
using ZNWalks.Infra.Identity.Domian.Models;

namespace ZNWalks.Infra.Identity.Repoistories
{
    public class AuthUnitOfWork : IAuthUnitOfWork
    {

        private readonly ZNWalksAuthDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private IAuthRepository? _authRepository;
        private ITokenRepository? _tokenRepository;

        public AuthUnitOfWork(ZNWalksAuthDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IAuthRepository AuthRepository
        {
            get
            {
                if (_authRepository is null)
                {
                    _authRepository = new AuthRepository(_dbContext, _userManager, _roleManager);
                }
                return _authRepository;
            }
        }
        public ITokenRepository TokenRepository
        {
            get
            {
                if (_tokenRepository is null)
                {
                    _tokenRepository = new TokenRepository(_dbContext);
                }
                return _tokenRepository;
            }
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
