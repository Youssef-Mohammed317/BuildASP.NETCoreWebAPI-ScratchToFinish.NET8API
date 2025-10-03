﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
using ZNWalks.Infra.Identity.Context;
using ZNWalks.Infra.Identity.Domian.Interfaces;
using ZNWalks.Infra.Identity.Domian.Models;
using ZNWalks.Infra.Identity.Repoistories;

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

            services.AddDbContext<ZNWalksAuthDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ZNWalksAuthConnectionString"));
            });
            #endregion

            #region Identity
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 4;
            })
            .AddEntityFrameworkStores<ZNWalksAuthDbContext>()
            .AddDefaultTokenProviders();
            #endregion

            #region JwtToken
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,

                   ValidIssuer = configuration["JWT:Issuer"],
                   ValidAudience = configuration["JWT:Audience"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]!)),
                   ClockSkew = TimeSpan.Zero
               };
           });
            #endregion


            #region UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthUnitOfWork, AuthUnitOfWork>();
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
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            #endregion
        }
    }
}
