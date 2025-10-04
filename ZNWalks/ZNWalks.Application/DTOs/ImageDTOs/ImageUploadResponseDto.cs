using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZNWalks.Application.DTOs.ImageDTOs
{
    public abstract class ImageUploadResponseDto
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
