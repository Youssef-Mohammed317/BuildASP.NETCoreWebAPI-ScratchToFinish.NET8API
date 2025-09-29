using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Application.DTOs.WalkDTOs;
using ZNWalks.Application.Interfaces;
using ZNWalks.Domain.Interfaces;
using ZNWalks.Domain.Models;

namespace ZNWalks.Application.Services
{
    public class WalkService : IWalkService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public WalkService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<WalkDto> CreateAsync(CreateWalkDto walkDto)
        {
            var walk = _mapper.Map<Walk>(walkDto);

            await _unitOfWork.WalkRepository.CreateAsync(walk);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<WalkDto>(walk);
        }

        public async Task<WalkDetailsDto?> DeleteByIdAsync(Guid id)
        {
            var walk = await _unitOfWork.WalkRepository.GetByIdAsync(id);
            if (walk == null)
            {
                return null;
            }

            _unitOfWork.WalkRepository.Delete(walk);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<WalkDetailsDto>(walk);

        }

        public async Task<IEnumerable<WalkDto>> GetAllAsync()
        {
            var walks = await _unitOfWork.WalkRepository.GetAll().ToListAsync();

            return _mapper.Map<IEnumerable<WalkDto>>(walks);
        }
        public async Task<IEnumerable<WalkDetailsDto>> GetAllWithDetailsAsync()
        {
            var walks = await _unitOfWork.WalkRepository.GetAll()
                .Include(w => w.Difficulty)
                .Include(w => w.Region)
                .ToListAsync();

            return _mapper.Map<IEnumerable<WalkDetailsDto>>(walks);
        }
        public async Task<WalkDetailsDto?> GetByIdAsync(Guid id)
        {
            var walk = await _unitOfWork.WalkRepository.GetByIdAsync(id);
            if (walk == null)
            {
                return null;
            }
            return _mapper.Map<WalkDetailsDto>(walk);
        }

        public async Task<WalkDetailsDto?> UpdateAsync(Guid id, UpdateWalkDto walkDto)
        {
            var walk = await _unitOfWork.WalkRepository.GetByIdAsync(id);

            if (walk == null)
            {
                return null;
            }

            _mapper.Map(walkDto, walk);

            _unitOfWork.WalkRepository.Update(walk);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<WalkDetailsDto>(walk);
        }
    }
}
