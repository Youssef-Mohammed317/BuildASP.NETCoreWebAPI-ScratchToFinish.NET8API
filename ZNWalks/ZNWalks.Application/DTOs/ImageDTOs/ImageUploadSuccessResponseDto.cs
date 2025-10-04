using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZNWalks.Application.DTOs.ImageDTOs
{
    public class ImageUploadSuccessResponseDto : ImageUploadResponseDto
    {

        public Guid? Id { get; set; }
        public IFormFile? File { get; set; }
        public string? FileName { get; set; }
        public string? FileDescrpition { get; set; }
        public string? FileExtension { get; set; }
        public long? FileSizeInBytes { get; set; }
        public string? FilePath { get; set; }
    }
}
