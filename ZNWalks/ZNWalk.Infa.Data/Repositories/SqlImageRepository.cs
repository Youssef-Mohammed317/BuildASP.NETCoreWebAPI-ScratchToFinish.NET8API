﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalk.Infa.Data.Contexts;
using ZNWalks.Domain.Interfaces;
using ZNWalks.Domain.Models;

namespace ZNWalk.Infa.Data.Repositories
{
    public class SqlImageRepository : IImageRepository
    {
        private readonly ZNWalksDbContext dbContext;

        public SqlImageRepository(ZNWalksDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task CreateAsync(Image image)
        {
            await dbContext.Image.AddAsync(image);
        }

        public void Delete(Image image)
        {
            dbContext.Image.Remove(image);
        }

        public async Task<Image?> GetByIdAsync(Guid id)
        {
            var image = await dbContext.Image.FirstOrDefaultAsync(img => img.Id == id);

            return image;
        }
    }
}
