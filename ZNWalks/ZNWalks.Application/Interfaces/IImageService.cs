using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Application.DTOs.ImageDTOs;

namespace ZNWalks.Application.Interfaces
{
    public interface IImageService
    {
        Task<ImageUploadResponseDto> UploadImageAsync(ImageUploadRequestDto request);
    }
}
