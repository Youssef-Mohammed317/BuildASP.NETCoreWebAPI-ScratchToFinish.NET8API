using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZNWalks.Application.DTOs.AuthDTOs.RegisterDTOs
{
    public class RegisterSuccessResponseDto : RegisterResponseDto
    {
        public string? UserId { get; set; }
    }
}
