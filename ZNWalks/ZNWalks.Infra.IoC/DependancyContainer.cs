using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNWalk.Infa.Data.Contexts;
using ZNWalk.Infa.Data.Repositories;
using ZNWalks.Application.AutoMapper.RegionProfiles;
using ZNWalks.Application.Interfaces;
using ZNWalks.Application.Services;
using ZNWalks.Domain.Interfaces;

namespace ZNWalks.Infra.IoC
{
    public static class DependancyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts
            services.AddDbContext<ZNWalksDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ZNWalksConnectionString"));
            });
            #endregion

            #region UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region AutoMapper
            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(typeof(RegionDomainToDtoProfile).Assembly); // for all profiles in this assembly :)
            });
            #endregion

            #region Services
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<IDifficultyService, DifficultyService>();
            services.AddScoped<IWalkService, WalkService>();
            #endregion
        }
    }
}
