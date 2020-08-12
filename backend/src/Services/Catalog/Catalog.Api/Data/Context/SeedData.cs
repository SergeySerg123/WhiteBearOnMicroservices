using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.Entities;

namespace WhiteBear.Services.Catalog.Api.Data.Context
{
    public static class SeedData
    {
        private const int ENTITY_COUNT = 20;

        public static async Task EnsurePopulated(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CatalogContext>();

                if (!context.ProductItems.Any())
                {
                    var categories = GenerateRandomCategories();
                    var brands = GenerateRandomBrands(categories);
                    var reactions = GenerateRandomReactions();
                    var products = GenerateRandomProducts(reactions, brands);

                    await context.Categories.AddRangeAsync(categories);
                    await context.Brands.AddRangeAsync(brands);
                    await context.ProductItems.AddRangeAsync(products);

                    await context.SaveChangesAsync();
                }

                if (!context.Bottles.Any())
                {
                    await context.AddRangeAsync(new Bottle[]
                    {
                        new Bottle() {Capacity = 0.5, Price=0.5},
                        new Bottle() {Capacity = 1, Price=0.7},
                        new Bottle() {Capacity = 1.5, Price=0.9},
                        new Bottle() {Capacity = 2, Price=1.1},
                    });

                    await context.SaveChangesAsync();
                }
            }
        }

        private static ICollection<Category> GenerateRandomCategories()
        {
            var categoriesFake = new Faker<Category>()
                .RuleFor(c => c.Id, f => f.UniqueIndex.ToString())
                .RuleFor(c => c.Name, f => f.Company.CompanyName());

            var categories = categoriesFake.Generate(ENTITY_COUNT);

            return categories;
        }

        private static ICollection<Brand> GenerateRandomBrands(ICollection<Category> categories)
        {
            var brandsFake = new Faker<Brand>()
                .RuleFor(b => b.Id, f => f.UniqueIndex.ToString())
                .RuleFor(b => b.Name, f => f.Company.CompanyName())
                .RuleFor(c => c.CategoryId, f => f.PickRandom(categories).Id);

            var brands = brandsFake.Generate(ENTITY_COUNT);

            return brands;
        }

        private static ICollection<Reaction> GenerateRandomReactions()
        {
            var reactionsFake = new Faker<Reaction>()
                .RuleFor(b => b.Value, f => f.Random.Int(1, 5));

            var reactions = reactionsFake.Generate(ENTITY_COUNT);

            return reactions;
        }

        private static ICollection<Product> GenerateRandomProducts(ICollection<Reaction> reactions, ICollection<Brand> brands)
        {
            var productsFake = new Faker<Product>()
                .RuleFor(b => b.Id, f => f.UniqueIndex.ToString())
                .RuleFor(b => b.Name, f => f.Company.CompanyName())
                .RuleFor(b => b.Description, f => f.Lorem.Text())
                .RuleFor(b => b.Price, f => f.Random.Decimal())
                .RuleFor(b => b.Reactions, f => new List<Reaction>(reactions))
                .RuleFor(b => b.PreviewImg, f => new Image { URL = "https://i.imgur.com/DCuEHzh.png" })
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
