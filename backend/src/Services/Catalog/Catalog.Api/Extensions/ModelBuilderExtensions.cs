using Microsoft.EntityFrameworkCore;
using WhiteBear.Services.Catalog.Api.Data.Entities;

namespace WhiteBear.Services.Catalog.Api.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ConfigureRelationships(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Reactions)
                .WithOne(r => r.Product)
                .OnDelete(DeleteBehavior.Restrict);               

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany(b => b.ProductItems)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(b => b.BrandId);

            modelBuilder.Entity<Reaction>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Reactions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(r => r.ProductId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Brands)
                .WithOne(c => c.Category)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(c => c.Category)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(c => c.CategoryId);
        }       
    }
}
