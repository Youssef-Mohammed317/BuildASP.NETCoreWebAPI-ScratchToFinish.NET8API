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
    public class RegionRepository : IRegionRepository
    {
        private readonly ZNWalksDbContext _dbContext;

        public RegionRepository(ZNWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Region region)
        {
            await _dbContext.Region.AddAsync(region);
        }

        public void Delete(Region region)
        {
            _dbContext.Region.Remove(region);
        }

        public IQueryable<Region> GetAll()
        {
            return _dbContext.Region.AsQueryable();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Region.FindAsync(id);
        }

        public void Update(Region region)
        {
            _dbContext.Region.Update(region);
        }

    }
}
