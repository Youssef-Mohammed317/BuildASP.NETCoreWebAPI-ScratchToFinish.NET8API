using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Application.DTOs.DifficultyDTOs;

namespace ZNWalks.Application.Interfaces
{
    public interface IDifficultyService
    {
        public Task<IEnumerable<DifficultyDto>> GetAllAsync();
        public Task<DifficultyDto?> GetByIdAsync(Guid id);
        public Task<DifficultyDto?> DeleteByIdAsync(Guid id);
        public Task<DifficultyDto?> UpdateAsync(Guid id, UpdateDifficultyDto difficultyDto);
        public Task<DifficultyDto> CreateAsync(CreateDifficultyDto difficultyDto);
    }
}
