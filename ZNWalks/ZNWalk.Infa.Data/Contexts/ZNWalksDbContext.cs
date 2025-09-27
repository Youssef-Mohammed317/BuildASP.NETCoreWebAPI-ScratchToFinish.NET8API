using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Domain.Models;

namespace ZNWalk.Infa.Data.Contexts
{
    public class ZNWalksDbContext : DbContext
    {
        public ZNWalksDbContext() : base()
        {
        }
        public ZNWalksDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Difficulty> Difficulty { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Walk> Walk {  get; set; }
    }
}
