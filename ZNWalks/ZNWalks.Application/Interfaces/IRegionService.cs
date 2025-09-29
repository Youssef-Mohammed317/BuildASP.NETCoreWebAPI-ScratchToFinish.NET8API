using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Application.DTOs.RegionDTOs;

namespace ZNWalks.Application.Interfaces
{
    public interface IRegionService
    {
        public Task<IEnumerable<RegionDto>> GetAllAsync();
        public Task<RegionDto> GetByIdAsync(Guid id);
        public Task<RegionDto> DeleteByIdAsync(Guid id);
        public Task<RegionDto> UpdateAsync(Guid id, UpdateRegionDto regionDto);
        public Task<RegionDto> CreateAsync(CreateRegionDto regionDto);
    }
}
