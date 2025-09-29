using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Application.DTOs.RegionDTOs;
using ZNWalks.Domain.Models;

namespace ZNWalks.Application.AutoMapper.RegionProfiles
{
    public class CreateRegionDtoToDomainProfile : Profile
    {
        public CreateRegionDtoToDomainProfile()
        {
            CreateMap<CreateRegionDto, Region>();
        }
    }
}
