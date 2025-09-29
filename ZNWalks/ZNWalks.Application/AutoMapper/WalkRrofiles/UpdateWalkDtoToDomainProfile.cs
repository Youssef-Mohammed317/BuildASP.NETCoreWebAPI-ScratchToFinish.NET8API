using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Application.DTOs.WalkDTOs;
using ZNWalks.Domain.Models;

namespace ZNWalks.Application.AutoMapper.WalkRrofiles
{
    public class UpdateWalkDtoToDomainProfile : Profile
    {
        public UpdateWalkDtoToDomainProfile()
        {
            CreateMap<UpdateWalkDto, Walk>();
        }
    }
}
