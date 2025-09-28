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

        public void Create(Region region)
        {
            _dbContext.Region.Add(region);
        }

        public void Delete(Region region)
        {
            _dbContext.Region.Remove(region);
        }

        public IQueryable<Region> GetAll()
        {
            return _dbContext.Region;
        }

        public Region GetById(Guid id)
        {
            return _dbContext.Region.Find(id)!;
        }

        public void Update(Region region)
        {
            _dbContext.Region.Update(region);
        }
    }
}
