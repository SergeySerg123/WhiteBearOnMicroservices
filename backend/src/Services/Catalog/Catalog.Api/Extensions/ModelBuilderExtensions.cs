using Bogus;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WhiteBear.Services.Catalog.Api.Data.Entities;

namespace WhiteBear.Services.Catalog.Api.Extensions
{
    public static class ModelBuilderExtensions
    {
        private const int ENTITY_COUNT = 20;

        public static void ConfigureRelationships(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Reactions)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);               

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(b => b.BrandId);

            modelBuilder.Entity<Product>()
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

        public static void Seed(this ModelBuilder modelBuilder)
        {
            var categories = GenerateRandomCategories();
            var brands = GenerateRandomBrands(categories);
            var products = GenerateRandomProducts(categories, brands);

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Brand>().HasData(brands);
            modelBuilder.Entity<Product>().HasData(products);
        }

        private static ICollection<Category> GenerateRandomCategories()
        {
            var categoriesFake = new Faker<Category>()
                .RuleFor(c => c.Id, f => f.UniqueIndex.ToString())
                .RuleFor(c => c.Name, f => f.Lorem.Text());

            var categories = categoriesFake.Generate(ENTITY_COUNT);

            return categories;
        }

        private static ICollection<Brand> GenerateRandomBrands(ICollection<Category> categories)
        {
            var brandsFake = new Faker<Brand>()
                .RuleFor(b => b.Id, f => f.UniqueIndex.ToString())
                .RuleFor(b => b.Name, f => f.Lorem.Text())
                .RuleFor(c => c.CategoryId, f => f.PickRandom(categories).Id);

            var brands = brandsFake.Generate(ENTITY_COUNT);

            return brands;
        }

        private static ICollection<Product> GenerateRandomProducts(ICollection<Category> categories, ICollection<Brand> brands)
        {
            var productsFake = new Faker<Product>()
                .RuleFor(b => b.Id, f => f.UniqueIndex.ToString())
                .RuleFor(b => b.Name, f => f.Lorem.Text())
                .RuleFor(b => b.BrandId, f => f.PickRandom(brands).Id);

            var products = productsFake.Generate(ENTITY_COUNT);

            foreach (var p in products)
            {
                var brand = brands.FirstOrDefault(b => b.Id == p.BrandId);

                p.CategoryId = brand.CategoryId;
            }

            return products;
        }
    }
}
