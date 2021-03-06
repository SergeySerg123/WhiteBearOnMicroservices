﻿using AutoMapper;
using WhiteBear.Services.Catalog.Api.Data.MappingProfiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WhiteBear.Services.Catalog.Api.Data.Context;
using WhiteBear.Services.Catalog.Api.Repositories;
using WhiteBear.Services.Catalog.Api.Repositories.Interfaces;
using WhiteBear.Services.Catalog.Api.Services;
using WhiteBear.Services.Catalog.Api.Services.Interfaces;

namespace WhiteBear.Services.Catalog.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ProductsService>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<BrandsService>();

            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<IBrandsRepository, BrandsRepository>();
        }

        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<BrandProfile>();
                cfg.AddProfile<CategoryProfile>();
                cfg.AddProfile<ProductProfile>();
                cfg.AddProfile<ReactionProfile>();
            },
            Assembly.GetExecutingAssembly());
        }

        public static void RegisterCustomDbConnection(this IServiceCollection services, IConfiguration configuration)
        {
            //When docker-compose are not exist
            //var server = configuration["DatabaseServer"];
            //var dbname = configuration["DatabaseName"];
            //var user = configuration["DatabaseUser"];
            //var password = configuration["DatabaseUserPassword"];
            //var connectionString = String.Format("Server={0}; Database={1}; User Id={2}; Password={3};", server, dbname, user, password);
            //services.AddDbContext<CatalogContext>(options =>
            //    options.UseSqlServer(connectionString));
            services.AddDbContext<CatalogContext>(options =>
                options.UseSqlServer(configuration["ConnectionString"]));
        }
    }
}
