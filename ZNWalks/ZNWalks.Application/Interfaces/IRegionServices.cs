using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Application.DTOs.RegionDTOs;

namespace ZNWalks.Application.Interfaces
{
    public interface IRegionServices
    {
        public IEnumerable<RegionDto> GetAll();
        public RegionDto GetById(Guid id);
        public void DeleteById(Guid id);
        public RegionDto Update(Guid id, UpdateRegionDto regionDto);
        public RegionDto Create(CreateRegionDto regionDto);
    }
}
