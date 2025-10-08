using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.DAL.Entites
{
    // 1-1 relationship with member shared [PK]
    public class HealthRecord : BaseEntity
    {
        // Id ==> FK [Member]
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public string BloodType { get; set; } = null!;
        public string? Note { get; set; }
    }
}
