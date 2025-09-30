﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZNWalks.Application.DTOs.DifficultyDTOs
{
    public class CreateDifficultyDto
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Name Must Be Less Than 30 Characters")]
        public string Name { get; set; }
    }
}
