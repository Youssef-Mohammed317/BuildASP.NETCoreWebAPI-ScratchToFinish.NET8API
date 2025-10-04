using AutoMapper;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Application.DTOs.DifficultyDTOs;
using ZNWalks.Application.DTOs.ImageDTOs;
using ZNWalks.Domain.Models;

namespace ZNWalks.Application.AutoMapper.ImageProfiles
{
    public class UploadImageDtoToDomainProfile : Profile
    {
        public UploadImageDtoToDomainProfile()
        {
            CreateMap<ImageUploadRequestDto, Image>()
                .ForMember(dest => dest.File, opt => opt.MapFrom(src => src.File))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.FileExtension, opt => opt.MapFrom(src => Path.GetExtension(src.File.FileName)))
                .ForMember(dest => dest.FileSizeInBytes, opt => opt.MapFrom(src => src.File.Length))
                .ForMember(dest => dest.FileDescrpition, opt => opt.MapFrom(src => src.FileDescription));
        }
    }
}
