using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZNWalks.Application.DTOs.Common.Sorting
{
    public class SortParam
    {
        public string? SortBy { get; set; }
        public bool SortDesc { get; set; } = false;
    }
}
