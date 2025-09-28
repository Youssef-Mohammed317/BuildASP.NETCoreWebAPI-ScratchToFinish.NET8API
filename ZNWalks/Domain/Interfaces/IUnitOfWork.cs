using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZNWalks.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRegionRepository RegionRepository { get; }
        IWalkRepository WalkRepository { get; }
        IDifficultyRepository DifficultyRepository { get; }
        Task SaveChangesAsync();
    }
}
