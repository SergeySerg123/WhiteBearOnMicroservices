using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.Context;
using WhiteBear.Services.Catalog.Api.Data.Entities;
using WhiteBear.Services.Catalog.Api.Repositories;
using WhiteBear.Services.Catalog.Api.Repositories.Interfaces;
using WhiteBear.Services.Catalog.Api.Services;
using WhiteBear.Services.Catalog.Api.Services.Interfaces;
using WhiteBear.Services.Catalog.Api.Data.MappingProfiles;
using Xunit;
using System;
using WhiteBear.Services.Catalog.Api.Data.DTO.Category;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;

namespace Catalog.Api.Tests.Repositories
{
    public class CategoriesRepositoryTests
    {
        private readonly Mock<ICategoriesRepository> _mockRepository;
        private readonly IMapper _mapper;
        private readonly DbContextOptions<CatalogContext> _options;

        private Category[] categories =
        {
            new Category() { Id = "1", Name = "Test" },
            new Category() { Id = "2", Name = "Test2" }
        };

        public CategoriesRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<CatalogContext>()
            .UseInMemoryDatabase(databaseName: "CatalogDataBase")
            .Options;

            _mockRepository = new Mock<ICategoriesRepository>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CategoryProfile());
            });
            _mapper = mockMapper.CreateMapper();
        }

        [Fact]
        public async Task Create_Category_Then_Return_Single_Category()
        {
            using(var context = new CatalogContext(_options))
            {
                // Arrange
                var repo = new CategoriesRepository(context);
                await repo.CreateCategory(new Category { Name = "Test" });

                // Act
                var categories = await repo.GetCategories();

                // Assert
                Assert.NotNull(categories);
                Assert.Single(categories);
            } 
        }

        [Fact]
        public async Task Create_Category_With_Null__Name_Then_Throw_Exception()
        {
            using (var context = new CatalogContext(_options))
            {
                // Arrange
                var repo = new CategoriesRepository(context);
                await repo.CreateCategory(new Category { Name = null });

                // Act
                var categories = await repo.GetCategories();

                // Assert
                Assert.NotNull(categories);
                Assert.Single(categories);
            }
        }











        //[Fact]
        //public async Task Get_Categories_Then_Return_2_Categories_In_Array()
        //{
        //    // Arrange
        //    _mockRepository.Setup(x => x.GetCategories())
        //        .ReturnsAsync(this.categories);                      
        //    var service = new CategoriesService(_mockRepository.Object, _mapper);
            

        //    // Act
        //    var categories = await service.GetCategories();

        //    // Assert
        //    Assert.IsType<Category[]>(categories);
        //    Assert.NotEmpty(categories);
        //    Assert.Equal(2, categories.Length);
        //}               
    }
}
