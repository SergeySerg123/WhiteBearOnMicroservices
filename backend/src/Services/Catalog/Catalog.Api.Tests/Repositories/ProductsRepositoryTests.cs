using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.Context;
using WhiteBear.Services.Catalog.Api.Data.Entities;
using WhiteBear.Services.Catalog.Api.Repositories;
using Xunit;

namespace Catalog.Api.Tests.Repositories
{
    public class ProductsRepositoryTests :IDisposable
    {
        private readonly DbContextOptions<CatalogContext> _options;
        private readonly CatalogContext _context;
        private readonly ProductsRepository _productsRepository;

        public ProductsRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<CatalogContext>()
            .UseInMemoryDatabase(databaseName: "ProductsDataBase")
            .Options;

            _context = new CatalogContext(_options);

            _productsRepository = new ProductsRepository(_context);
        }

        [Fact]
        public async Task Get_Product_Item_Then_Return_Exist_Product()
        {
            // Arrange
            await _productsRepository.CreateProduct(new ProductItem { Id = "1", Name = "Test", CategoryId = "1", BrandId="1" });

            // Act
            var product = await _productsRepository.GetProductItem("1");

            // Assert
            Assert.NotNull(product);
            Assert.Equal("Test", product.Name);
            Assert.Equal("1", product.Id);
            Assert.Equal("1", product.CategoryId);
            Assert.Equal("1", product.BrandId);
        }

        [Fact]
        public async Task Get_Not_Exist_Product_Item_Then_Return_Null()
        {
            // Arrange
            await _productsRepository.CreateProduct(new ProductItem { Id = "1", Name = "Test", CategoryId = "1", BrandId = "1" });

            // Act
            var product = await _productsRepository.GetProductItem("2");

            // Assert
            Assert.Null(product);
        }

        [Fact]
        public async Task Create_Product_Then_Return_Single_Product()
        {

            // Arrange
            await _productsRepository.CreateProduct(new ProductItem { Id = "1", Name = "Test", CategoryId = "1", BrandId = "1" });

            // Act
            //var products = await _productsRepository.GetProducts();

            // Assert
            //Assert.Single(products);

        }

        [Fact]
        public async Task Update_Product_Name_Then_Return_Product_With_New_Name()
        {

            // Act - 1
            await _productsRepository.CreateProduct(new ProductItem { Id = "1", Name = "Test", CategoryId = "1", BrandId = "1" });
            var p = await _productsRepository.GetProductItem("1");

            // Assert - 1
            Assert.Equal("Test", p.Name);

            // Act - 2
            p.Name = "Test-2";
            await _productsRepository.UpdateProduct(p);
            var p2 = await _productsRepository.GetProductItem("1");

            // Assert - 2
            Assert.Equal("Test-2", p2.Name);

        }

        [Fact]
        public async Task Delete_Product_Then_Return_Null()
        {
            // Act - 1
            await _productsRepository.CreateProduct(new ProductItem { Id = "1", Name = "Test", CategoryId = "1", BrandId = "1" });
            var b = await _productsRepository.GetProductItem("1");

            // Assert - 1
            Assert.NotNull(b);

            // Act - 2;
            await _productsRepository.DeleteProduct(b);
            var b2 = await _productsRepository.GetProductItem("1");

            // Assert - 2
            Assert.Null(b2);

        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            GC.Collect();
        }
    }
}
