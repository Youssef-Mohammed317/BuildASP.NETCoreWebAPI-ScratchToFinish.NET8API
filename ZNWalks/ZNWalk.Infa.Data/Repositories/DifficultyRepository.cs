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
    public class DifficultyRepository : IDifficultyRepository
    {
        private readonly ZNWalksDbContext _dbContext;

        public DifficultyRepository(ZNWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Difficulty difficulty)
        {
            await _dbContext.Difficulty.AddAsync(difficulty);
        }

        public void Delete(Difficulty difficulty)
        {
            _dbContext.Difficulty.Remove(difficulty);
        }

        public IQueryable<Difficulty> GetAll()
        {
            return _dbContext.Difficulty.AsQueryable();
        }

        public async Task<Difficulty?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Difficulty
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public void Update(Difficulty difficulty)
        {
            _dbContext.Difficulty.Update(difficulty);
        }
    }
}
