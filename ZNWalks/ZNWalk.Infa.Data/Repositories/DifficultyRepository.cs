using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalk.Infa.Data.Contexts;
using ZNWalks.Domain.Interfaces;

namespace ZNWalk.Infa.Data.Repositories
{
    public class DifficultyRepository : IDifficultyRepository
    {
        private readonly ZNWalksDbContext _dbContext;

        public DifficultyRepository(ZNWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
