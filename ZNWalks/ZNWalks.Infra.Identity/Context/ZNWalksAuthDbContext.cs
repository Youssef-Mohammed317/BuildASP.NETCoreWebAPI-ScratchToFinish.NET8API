using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Infra.Identity.Domian.Models;
using ZNWalks.Infra.Identity.Seads;

namespace ZNWalks.Infra.Identity.Context
{
    public class ZNWalksAuthDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public  DbSet<TokenStore> TokenStore {  get; set; }
        public ZNWalksAuthDbContext(DbContextOptions<ZNWalksAuthDbContext> options) : base(options)
        {
        }

        public ZNWalksAuthDbContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeadZNWalksAuthDb.SeadRoles(builder);
        }
    }
}
