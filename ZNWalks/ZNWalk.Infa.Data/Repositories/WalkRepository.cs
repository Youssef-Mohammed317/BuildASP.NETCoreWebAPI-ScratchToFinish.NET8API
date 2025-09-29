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
        private readonly ZNWalksDbContext _dbContext;

        public WalkRepository(ZNWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Walk walk)
        {
            await _dbContext.Walk.AddAsync(walk);
        }

        public void Delete(Walk walk)
        {
            _dbContext.Walk.Remove(walk);
        }

        public IQueryable<Walk> GetAll()
        {
            return _dbContext.Walk.AsQueryable();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Walk
                .Include(w => w.Difficulty)
                .Include(w => w.Region)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public void Update(Walk walk)
        {
            _dbContext.Walk.Update(walk);
        }
    }
}
