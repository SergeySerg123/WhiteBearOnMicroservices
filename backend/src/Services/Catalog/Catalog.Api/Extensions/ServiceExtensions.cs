﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhiteBear.Services.Catalog.Api.Data.Context;
using WhiteBear.Services.Catalog.Api.Repositories;
using WhiteBear.Services.Catalog.Api.Services;

namespace WhiteBear.Services.Catalog.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterCustomServices(this IServiceCollection services)
        {
            services.AddScoped<CatalogService>();
            services.AddScoped<ICatalogRepository, CatalogRepository>();
        }

        public static void SeedCustomData(this IServiceCollection services)
        {
            var context = services.BuildServiceProvider()
                       .GetService<CatalogContext>();
            //TODO Seed data
            //CatalogSeed.SeedAsync(context).Wait();
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