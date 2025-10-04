using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalk.Infa.Data.Contexts;
using ZNWalks.Domain.Interfaces;
using ZNWalks.Domain.Models;

namespace ZNWalk.Infa.Data.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly ZNWalksDbContext dbContext;

        public WalkRepository(ZNWalksDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task CreateAsync(Walk walk)
        {
            await dbContext.Walk.AddAsync(walk);
        }

        public void Delete(Walk walk)
        {
            dbContext.Walk.Remove(walk);
        }

        public IQueryable<Walk> GetAll()
        {
            return dbContext.Walk.AsQueryable();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dbContext.Walk
                .Include(w => w.Difficulty)
                .Include(w => w.Region)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public void Update(Walk walk)
        {
            dbContext.Walk.Update(walk);
        }
    }
}
