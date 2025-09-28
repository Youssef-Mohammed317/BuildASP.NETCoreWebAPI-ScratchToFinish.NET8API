using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalk.Infa.Data.Contexts;
using ZNWalks.Domain.Interfaces;

namespace ZNWalk.Infa.Data.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly ZNWalksDbContext _dbContext;

        public WalkRepository(ZNWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
