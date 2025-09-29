using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Domain.Models;

namespace ZNWalks.Application.DTOs.WalkDTOs
{
    public class WalkDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }
    }
}
