using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using WhiteBear.Services.Catalog.Api.Data.Entities;

namespace WhiteBear.Services.Catalog.Api.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductItem>()
                .HasMany(p => p.Reactions)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductItem>()
                .HasOne(p => p.Brand)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(b => b.BrandId);

            modelBuilder.Entity<ProductItem>()
                .HasOne(p => p.Category)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reaction>()
                .HasOne(r => r.ProductItem)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(r => r.ProductItemId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.ProductItems)
                .WithOne()
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Brands)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<Brand>()
                .HasOne(b => b.Category)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Brand>()
                .HasMany(b => b.ProductItems)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
        }

        //public static void Seed(this ModelBuilder modelBuilder)
        //{
        //    var categories = GenerateRandomCategories();
        //    var brands = GenerateRandomBrands();
        //    var products = GenerateRandomProducts();
        //}

        //private static ICollection<Category> GenerateRandomCategories()
        //{

        //}
    }
}
