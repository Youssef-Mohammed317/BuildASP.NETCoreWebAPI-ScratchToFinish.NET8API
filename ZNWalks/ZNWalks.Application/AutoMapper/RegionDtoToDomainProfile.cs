using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Application.DTOs.RegionDTOs;
using ZNWalks.Domain.Models;

namespace ZNWalks.Application.AutoMapper
{
    public class RegionDtoToDomainProfile : Profile
    {
        public RegionDtoToDomainProfile()
        {
            CreateMap<CreateRegionDto, Region>();
            CreateMap<UpdateRegionDto, Region>();
        }
    }
}
