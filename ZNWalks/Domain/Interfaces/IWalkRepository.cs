using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Domain.Models;

namespace ZNWalks.Domain.Interfaces
{
    public interface IWalkRepository
    {
        IQueryable<Walk> GetAll();
        Task<Walk?> GetByIdAsync(Guid id);
        Task CreateAsync(Walk walk);
        void Update(Walk walk);
        void Delete(Walk walk);
    }
}
