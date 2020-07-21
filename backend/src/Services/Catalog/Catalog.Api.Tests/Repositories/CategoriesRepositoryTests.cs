using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.Context;
using WhiteBear.Services.Catalog.Api.Data.Entities;
using WhiteBear.Services.Catalog.Api.Repositories;
using WhiteBear.Services.Catalog.Api.Repositories.Interfaces;
using WhiteBear.Services.Catalog.Api.Data.MappingProfiles;
using Xunit;
using System;

namespace Catalog.Api.Tests.Repositories
{
    public class CategoriesRepositoryTests : IDisposable
    {
        private readonly Mock<ICategoriesRepository> _mockRepository;
        private readonly IMapper _mapper;
        private readonly DbContextOptions<CatalogContext> _options;
        private readonly CatalogContext _context;
        private readonly CategoriesRepository _categoriesRepository;

        public CategoriesRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<CatalogContext>()
            .UseInMemoryDatabase(databaseName: "CatalogDataBase")
            .Options;

            _context = new CatalogContext(_options);

            _categoriesRepository = new CategoriesRepository(_context);

            _mockRepository = new Mock<ICategoriesRepository>();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CategoryProfile());
            });

            _mapper = mockMapper.CreateMapper();
        }

        [Fact]
        public async Task Get_Category_Item_Return_Exist_Category()
        {
            // Arrange
            
            await _categoriesRepository.CreateCategory(new Category { Id = "1", Name = "Test" });

            // Act
            var category = await _categoriesRepository.GetCategoryItem("1");

            // Assert
            Assert.NotNull(category);
            Assert.Equal("Test", category.Name);
            Assert.Equal("1", category.Id);

        }

        [Fact]
        public async Task Get_Not_Exist_Category_Item_Then_Return_Null()
        {

            // Arrange
            await _categoriesRepository.CreateCategory(new Category { Id = "1", Name = "Test" });

            // Act
            var category = await _categoriesRepository.GetCategoryItem("2");

            // Assert
            Assert.Null(category);

        }

        [Fact]
        public async Task Create_Category_Then_Return_Single_Category()
        {

            // Arrange
            await _categoriesRepository.CreateCategory(new Category { Name = "Test" });

            // Act
            var categories = await _categoriesRepository.GetCategories();

            // Assert
            Assert.Single(categories);

        }

        [Fact]
        public async Task Update_Category_Name_Then__Return_Category_With_New_Name()
        {

            // Act - 1
            await _categoriesRepository.CreateCategory(new Category { Id = "1", Name = "TestName" });
            var c = await _categoriesRepository.GetCategoryItem("1");

            // Assert - 1
            Assert.Equal("TestName", c.Name);

            // Act - 2
            c.Name = "Test-2";
            await _categoriesRepository.UpdateCategory(c);
            var c2 = await _categoriesRepository.GetCategoryItem("1");

            // Assert - 2
            Assert.Equal("Test-2", c2.Name);

        }

        [Fact]
        public async Task Delete_Category_Then__Return_Null()
        {
            // Act - 1
            await _categoriesRepository.CreateCategory(new Category { Id = "1", Name = "TestName" });
            var c = await _categoriesRepository.GetCategoryItem("1");

            // Assert - 1
            Assert.NotNull(c);

            // Act - 2;
            await _categoriesRepository.DeleteCategory(c);
            var c2 = await _categoriesRepository.GetCategoryItem("1");

            // Assert - 2
            Assert.Null(c2);

        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }    
    }
}
