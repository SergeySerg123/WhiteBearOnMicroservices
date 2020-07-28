using Microsoft.EntityFrameworkCore;
using WhiteBear.Services.Catalog.Api.Data.Entities;
using WhiteBear.Services.Catalog.Api.Extensions;

namespace WhiteBear.Services.Catalog.Api.Data.Context
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base (options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureRelationships();
        }

        public DbSet<Product> ProductItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
    }
}
