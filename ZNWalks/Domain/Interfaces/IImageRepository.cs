using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalks.Domain.Models;

namespace ZNWalks.Domain.Interfaces
{
    public interface IImageRepository
    {
        Task CreateAsync(Image image);
    }
}
