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
        private readonly ZNWalksDbContext _dbContext;
        private IRegionRepository? _regionRepository;
        private IDifficultyRepository? _difficultyRepository;
        private IWalkRepository? _walkRepository;

        public UnitOfWork(ZNWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IRegionRepository RegionRepository
        {
            get
            {
                if (_regionRepository is null)
                {
                    _regionRepository = new RegionRepository(_dbContext);
                }
                return _regionRepository;
            }
        }
        public IWalkRepository WalkRepository
        {
            get
            {
                if (_walkRepository is null)
                {
                    _walkRepository = new WalkRepository(_dbContext);
                }
                return _walkRepository;
            }
        }
        public IDifficultyRepository DifficultyRepository
        {
            get
            {
                if (_difficultyRepository is null)
                {
                    _difficultyRepository = new DifficultyRepository(_dbContext);
                }
                return _difficultyRepository;
            }
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}
