using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Application.DTOs.DifficultyDTOs;
using ZNWalks.Domain.Models;

namespace ZNWalks.Application.AutoMapper.DifficultyProfiles
{
    public class DifficultyDomainToDtoProfile : Profile
    {
        public DifficultyDomainToDtoProfile()
        {
            CreateMap<Difficulty, DifficultyDto>();
        }
    }
}
