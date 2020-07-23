using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.Context;
using WhiteBear.Services.Catalog.Api.Data.Entities;
using WhiteBear.Services.Catalog.Api.Repositories;
using Xunit;


namespace Catalog.Api.Tests.Repositories
{
    public class BrandsRepositoryTests : IDisposable
    {
        private readonly DbContextOptions<CatalogContext> _options;
        private readonly CatalogContext _context;
        private readonly BrandsRepository _brandsRepository;

        public BrandsRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<CatalogContext>()
            .UseInMemoryDatabase(databaseName: "BrandsDataBase")
            .Options;

            _context = new CatalogContext(_options);

            _brandsRepository = new BrandsRepository(_context);
        }

        [Fact]
        public async Task Get_Brand_Item_Then_Return_Exist_Brand()
        {
            // Arrange
            await _brandsRepository.CreateBrand(new Brand { Id = "1", Name = "Test", CategoryId="1" });

            // Act
            var brand = await _brandsRepository.GetBrandItem("1");

            // Assert
            Assert.NotNull(brand);
            Assert.Equal("Test", brand.Name);
            Assert.Equal("1", brand.Id);
            Assert.Equal("1", brand.CategoryId);

        }

        [Fact]
        public async Task Get_Not_Exist_Brand_Item_Then_Return_Null()
        {
            // Arrange
            await _brandsRepository.CreateBrand(new Brand { Id = "1", Name = "Test", CategoryId = "1" });

            // Act
            var brand = await _brandsRepository.GetBrandItem("2");

            // Assert
            Assert.Null(brand);
        }

        [Fact]
        public async Task Create_Brand_Then_Return_Single_Brand()
        {

            // Arrange
            await _brandsRepository.CreateBrand(new Brand { Id = "1", Name = "Test", CategoryId = "1" });

            // Act
            var brands = await _brandsRepository.GetBrands();

            // Assert
            Assert.Single(brands);

        }

        [Fact]
        public async Task Update_Brand_Name_Then__Return_Brand_With_New_Name()
        {

            // Act - 1
            await _brandsRepository.CreateBrand(new Brand { Id = "1", Name = "Test", CategoryId = "1" });
            var b = await _brandsRepository.GetBrandItem("1");

            // Assert - 1
            Assert.Equal("Test", b.Name);

            // Act - 2
            b.Name = "Test-2";
            await _brandsRepository.UpdateBrand(b);
            var b2 = await _brandsRepository.GetBrandItem("1");

            // Assert - 2
            Assert.Equal("Test-2", b2.Name);

        }

        [Fact]
        public async Task Delete_Brand_Then_Return_Null()
        {
            // Act - 1
            await _brandsRepository.CreateBrand(new Brand { Id = "1", Name = "Test", CategoryId = "1" });
            var b = await _brandsRepository.GetBrandItem("1");

            // Assert - 1
            Assert.NotNull(b);

            // Act - 2;
            await _brandsRepository.DeleteBrand(b);
            var b2 = await _brandsRepository.GetBrandItem("1");

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
