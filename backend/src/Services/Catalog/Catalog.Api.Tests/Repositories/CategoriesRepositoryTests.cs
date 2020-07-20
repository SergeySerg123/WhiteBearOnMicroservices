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
        public async Task Get_Category_Item_Return_Exist_Category()
        {
            using (var context = new CatalogContext(_options))
            {
                // Arrange
                var repo = new CategoriesRepository(context);
                await repo.CreateCategory(new Category { Id="1", Name = "Test" });

                // Act
                var category = await repo.GetCategoryItem("1");

                // Assert
                Assert.NotNull(category);
            }
        }

        [Fact]
        public async Task Get_Not_Exist_Category_Item_Then_Return_Null()
        {
            using (var context = new CatalogContext(_options))
            {
                // Arrange
                var repo = new CategoriesRepository(context);
                await repo.CreateCategory(new Category { Id = "1", Name = "Test" });

                // Act
                var category = await repo.GetCategoryItem("2");

                // Assert
                Assert.Null(category);
            }
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
                Assert.Single(categories);
            } 
        }

        [Fact]
        public async Task Update_Category_Name_Then__Return_Category_With_New_Name()
        {
            using (var context = new CatalogContext(_options))
            {
                // Arrange
                var repo = new CategoriesRepository(context);

                // Act - 1
                await repo.CreateCategory(new Category { Id="1", Name = "TestName" });
                var c = await repo.GetCategoryItem("1");

                // Assert - 1
                Assert.Equal("TestName", c.Name);

                // Act - 2
                c.Name = "Test-2";
                await repo.UpdateCategory(c);
                var c2 = await repo.GetCategoryItem("1");
                
                // Assert - 2
                Assert.Equal("Test-2", c2.Name);
            }
        }

        [Fact]
        public async Task Delete_Category_Then__Return_Null()
        {
            using (var context = new CatalogContext(_options))
            {
                // Arrange
                var repo = new CategoriesRepository(context);

                // Act - 1
                await repo.CreateCategory(new Category { Id = "1", Name = "TestName" });
                var c = await repo.GetCategoryItem("1");

                // Assert - 1
                Assert.NotNull(c);

                // Act - 2;
                await repo.DeleteCategory(c);
                var c2 = await repo.GetCategoryItem("1");

                // Assert - 2
                Assert.Null(c2);
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
