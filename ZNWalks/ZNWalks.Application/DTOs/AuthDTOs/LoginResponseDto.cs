using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZNWalks.Application.DTOs.AuthDTOs
{
    public class LoginResponseDto
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? UserId { get; set; }
        public string? Token { get; set; }
    }
}
