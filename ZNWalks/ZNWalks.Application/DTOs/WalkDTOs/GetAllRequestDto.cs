using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Application.DTOs.Common.Filtering;
using ZNWalks.Application.DTOs.Common.Paginate;
using ZNWalks.Application.DTOs.Common.Sorting;

namespace ZNWalks.Application.DTOs.WalkDTOs
{
    public class GetAllRequestDto
    {
        public List<FilterParam?>? filterParams { get; set; } = new();
        public List<SortParam?>? sortParams { get; set; }
        public PaginateParam? paginateParam { get; set; }
    }
}
