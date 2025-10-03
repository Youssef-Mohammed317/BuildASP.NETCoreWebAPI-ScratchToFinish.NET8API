using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Infra.Identity.Context;
using ZNWalks.Infra.Identity.Domian.Interfaces;
using ZNWalks.Infra.Identity.Domian.Models;

namespace ZNWalks.Infra.Identity.Repoistories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ZNWalksAuthDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AuthRepository(ZNWalksAuthDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> AddUserToRolesAsync(ApplicationUser user, IEnumerable<string> roles)
        {
            var result = await _userManager.AddToRolesAsync(user, roles);

            return result;
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            var result = await _userManager.CheckPasswordAsync(user, password);

            return result;
        }

        public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            return result;
        }
        public async Task<IdentityResult> DeleteUserAsync(ApplicationUser user)
        {
            var result = await _userManager.DeleteAsync(user);

            return result;
        }

        public async Task<ApplicationUser?> FindByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user;
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            return roles;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }
    }
}
