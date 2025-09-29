using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Application.DTOs.WalkDTOs;

namespace ZNWalks.Application.Interfaces
{
    public interface IWalkService
    {
        public Task<IEnumerable<WalkDto>> GetAllAsync();
        public Task<IEnumerable<WalkDetailsDto>> GetAllWithDetailsAsync();
        public Task<WalkDetailsDto?> GetByIdAsync(Guid id);
        public Task<WalkDetailsDto?> DeleteByIdAsync(Guid id);
        public Task<WalkDetailsDto?> UpdateAsync(Guid id, UpdateWalkDto walkDto);
        public Task<WalkDto> CreateAsync(CreateWalkDto walkDto);
    }
}
