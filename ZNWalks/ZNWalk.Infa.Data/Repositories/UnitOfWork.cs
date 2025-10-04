using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalk.Infa.Data.Contexts;
using ZNWalks.Domain.Interfaces;

namespace ZNWalk.Infa.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ZNWalksDbContext dbContext;
        private IRegionRepository? regionRepository;
        private IDifficultyRepository? difficultyRepository;
        private IWalkRepository? walkRepository;
        private IImageRepository? imageRepository;

        public UnitOfWork(ZNWalksDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public IRegionRepository RegionRepository
        {
            get
            {
                if (regionRepository is null)
                {
                    regionRepository = new RegionRepository(dbContext);
                }
                return regionRepository;
            }
        }
        public IWalkRepository WalkRepository
        {
            get
            {
                if (walkRepository is null)
                {
                    walkRepository = new WalkRepository(dbContext);
                }
                return walkRepository;
            }
        }
        public IDifficultyRepository DifficultyRepository
        {
            get
            {
                if (difficultyRepository is null)
                {
                    difficultyRepository = new DifficultyRepository(dbContext);
                }
                return difficultyRepository;
            }
        }
        public IImageRepository ImageRepository
        {
            get
            {
                if (imageRepository is null)
                {
                    imageRepository = new ImageRepository(dbContext);
                }
                return imageRepository;
            }
        }
        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }

    }
}
