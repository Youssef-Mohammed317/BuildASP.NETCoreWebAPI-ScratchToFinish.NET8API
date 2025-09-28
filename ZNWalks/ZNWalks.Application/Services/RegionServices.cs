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

        public RegionDto Create(CreateRegionDto regionDto)
        {
            var region = new Region()
            {
                Name = regionDto.Name,
                Code = regionDto.Code,
                RegionImageUrl = regionDto.RegionImageUrl,
            };
            _unitOfWork.RegionRepository.Create(region);

            _unitOfWork.SaveChanges();

            return new RegionDto
            {
                Id = region.Id,
                Name = regionDto.Name,
                Code = regionDto.Code,
                RegionImageUrl = regionDto.RegionImageUrl,
            };
        }

        public void DeleteById(Guid id)
        {
            var region = _unitOfWork.RegionRepository.GetById(id);
            if (region == null)
            {
                throw new Exception("Not Found");
            }
            _unitOfWork.RegionRepository.Delete(region);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<RegionDto> GetAll()
        {
            var regions = new List<RegionDto>();
            foreach (var region in _unitOfWork.RegionRepository.GetAll())
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
        public RegionDto GetById(Guid id)
        {
            var region = _unitOfWork.RegionRepository.GetById(id);
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

        public RegionDto Update(Guid id, UpdateRegionDto regionDto)
        {
            var region = _unitOfWork.RegionRepository.GetById(id);
            if (region == null)
            {
                throw new Exception("Not Found");
            }
            region.Name = regionDto.Name;
            region.Code = regionDto.Code;
            region.RegionImageUrl = regionDto.RegionImageUrl;
            _unitOfWork.RegionRepository.Update(region);
            _unitOfWork.SaveChanges();

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
