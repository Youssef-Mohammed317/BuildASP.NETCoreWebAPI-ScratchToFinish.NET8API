using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Application.DTOs.RegionDTOs;
using ZNWalks.Application.Interfaces;
using ZNWalks.Domain.Interfaces;
using ZNWalks.Domain.Models;

namespace ZNWalks.Application.Services
{
    public class RegionServices : IRegionServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegionServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RegionDto> CreateAsync(CreateRegionDto regionDto)
        {
            var region = new Region()
            {
                Name = regionDto.Name,
                Code = regionDto.Code,
                RegionImageUrl = regionDto.RegionImageUrl,
            };
            await _unitOfWork.RegionRepository.CreateAsync(region);

            await _unitOfWork.SaveChangesAsync();

            return new RegionDto
            {
                Id = region.Id,
                Name = regionDto.Name,
                Code = regionDto.Code,
                RegionImageUrl = regionDto.RegionImageUrl,
            };
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var region = await _unitOfWork.RegionRepository.GetByIdAsync(id);
            if (region == null)
            {
                throw new Exception("Not Found");
            }
            _unitOfWork.RegionRepository.Delete(region);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<RegionDto>> GetAllAsync()
        {
            var regions = new List<RegionDto>();
            foreach (var region in await _unitOfWork.RegionRepository.GetAll().ToListAsync())
            {
                regions.Add(new RegionDto()
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl
                });
            }
            return regions;
        }
        public async Task<RegionDto> GetByIdAsync(Guid id)
        {
            var region = await _unitOfWork.RegionRepository.GetByIdAsync(id);
            if (region != null)
            {
                return new RegionDto()
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl
                };
            }
            return null!;
        }

        public async Task<RegionDto> UpdateAsync(Guid id, UpdateRegionDto regionDto)
        {
            var region = await _unitOfWork.RegionRepository.GetByIdAsync(id);
            if (region == null)
            {
                throw new Exception("Not Found");
            }
            region.Name = regionDto.Name;
            region.Code = regionDto.Code;
            region.RegionImageUrl = regionDto.RegionImageUrl;
            _unitOfWork.RegionRepository.Update(region);
            await _unitOfWork.SaveChangesAsync();

            return new RegionDto
            {
                Id = id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = region.RegionImageUrl
            };
        }
    }
}
