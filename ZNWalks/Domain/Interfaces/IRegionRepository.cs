using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Domain.Models;

namespace ZNWalks.Domain.Interfaces
{
    public interface IRegionRepository
    {
        IQueryable<Region> GetAll();
        Task<Region?> GetByIdAsync(Guid id);
        Task CreateAsync(Region region);
        void Update(Region region);
        void Delete(Region region);
    }
}
