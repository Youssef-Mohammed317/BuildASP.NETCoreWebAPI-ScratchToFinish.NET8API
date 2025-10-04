using AutoMapper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Application.DTOs.ImageDTOs;
using ZNWalks.Application.Interfaces;
using ZNWalks.Domain.Interfaces;
using ZNWalks.Domain.Models;
namespace ZNWalks.Application.Services
{
    public class ImageService : IImageService
    {
        private readonly long maxFileSize = 10 * 1024 * 1024; // 10MB
        private readonly string[] allowedExtensions = [".jpg", ".png", ".jpeg"];

        private readonly IUnitOfWork unitOfWork;
        private readonly IHostEnvironment hostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;

        public ImageService(IUnitOfWork _unitOfWork, IHostEnvironment _hostEnvironment, IHttpContextAccessor _httpContextAccessor, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            hostEnvironment = _hostEnvironment;
            httpContextAccessor = _httpContextAccessor;
            mapper = _mapper;
        }

        public async Task<ImageUploadResponseDto> UploadImageAsync(ImageUploadRequestDto request)
        {

            ImageUploadResponseDto result = ValidateFileUpload(request);

            if (!result.Success)
            {
                return result;
            }
            var imageDomain = mapper.Map<Image>(request);

            imageDomain.StoredFileName = Guid.NewGuid();

            var urlFilePath = await GenerateUrlPath(imageDomain);

            imageDomain.FilePath = urlFilePath;

            await unitOfWork.ImageRepository.CreateAsync(imageDomain);
            await unitOfWork.SaveChangesAsync();

            return new ImageUploadSuccessResponseDto
            {
                Success = true,
                Message = "File Uploaded Successfully",
                FilePath = urlFilePath,
                FileSizeInBytes = imageDomain.FileSizeInBytes,
                FileName = imageDomain.FileName,
                File = imageDomain.File,
                FileDescrpition = imageDomain.FileDescrpition,
                FileExtension = imageDomain.FileExtension,
                Id = imageDomain.Id
            };
        }

        private ImageUploadResponseDto ValidateFileUpload(ImageUploadRequestDto request)
        {
            var fileExtension = Path.GetExtension(request.File.FileName);

            if (!allowedExtensions.Contains(fileExtension))
            {
                return new ImageUploadFailureResponseDto
                {
                    Success = false,
                    Message = "Unsupported file extension"
                };
            }

            if (request.File.Length > maxFileSize)
            {
                return new ImageUploadFailureResponseDto
                {
                    Success = false,
                    Message = "File size is more than 10MB"
                };
            }


            return new ImageUploadFailureResponseDto
            {
                Success = true,
                Message = "File Validated Successfully"
            };
        }

        private async Task<string> GenerateUrlPath(Image imageDomain)
        {

            var localFilePath = Path.Combine(hostEnvironment.ContentRootPath, "Images",
                $"{imageDomain.StoredFileName}{imageDomain.FileExtension}");

            using var stream = new FileStream(localFilePath, FileMode.Create);
            await imageDomain.File.CopyToAsync(stream);
            var httpRequest = httpContextAccessor.HttpContext.Request;
            var urlFilePath =
                $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/{imageDomain.StoredFileName}{imageDomain.FileExtension}";

            return urlFilePath;
        }
    }
}
