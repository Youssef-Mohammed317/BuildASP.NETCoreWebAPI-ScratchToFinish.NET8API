﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZNWalks.Application.DTOs.AuthDTOs.RegisterDTOs
{
    public abstract class RegisterResponseDto
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
