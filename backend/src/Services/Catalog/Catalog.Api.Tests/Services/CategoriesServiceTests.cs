using AutoMapper;
using Moq;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.DTO.Category;
using WhiteBear.Services.Catalog.Api.Data.Entities;
using WhiteBear.Services.Catalog.Api.Data.MappingProfiles;
using WhiteBear.Services.Catalog.Api.Infrastructure.Exceptions;
using WhiteBear.Services.Catalog.Api.Repositories.Interfaces;
using WhiteBear.Services.Catalog.Api.Services;
using Xunit;

namespace Catalog.Api.Tests.Services
{
    public class CategoriesServiceTests
    {
        private readonly Mock<ICategoriesRepository> _mockRepository;
        private readonly IMapper _mapper;
        private readonly CategoriesService _categoriesService;

        public CategoriesServiceTests()
        {
            _mockRepository = new Mock<ICategoriesRepository>();
            
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CategoryProfile());
            });

            _mapper = mockMapper.CreateMapper();
            _categoriesService = new CategoriesService(_mockRepository.Object, _mapper);
        }

        [Fact]
        public async Task Get_Categories_Then_Return_Category_Array()
        {
            // Arrange
            _mockRepository.Setup(x => x.GetCategories())
                .ReturnsAsync(new Category[] { 
                    new Category() { Id="1", Name = "Test" },
                    new Category() { Id="2", Name = "Test-2" }
                });

            // Act 
            var categories = await _categoriesService.GetCategories();

            // Assert
            Assert.IsType<Category[]>(categories);
            Assert.NotNull(categories);
        }

        [Fact]
        public async Task Get_Exist_Category_Item_Then_Return_Category()
        {
            // Arrange
            _mockRepository.Setup(x => x.GetCategoryItem(It.IsAny<string>()))
                .ReturnsAsync(new Category() { Id="1", Name = "Test" });

            // Act 
            var category = await _categoriesService.GetCategoryById("1");

            // Assert
            Assert.IsType<Category>(category);
            Assert.NotNull(category);
        }

        [Fact]
        public async Task Get_Unexist_Category_Item_Then_Throw_NotFoundEntityException()
        {
            // Arrange
            _mockRepository.Setup(x => x.GetCategoryItem(It.Is<string>(s => s.Equals("1"))))
                .ReturnsAsync(new Category() { Id = "1", Name = "Test" });

            // Act and Assert 
            await Assert.ThrowsAsync<NotFoundEntityException>(() =>
                _categoriesService.GetCategoryById("0"));
        }

        [Fact]
        public async Task Create_Category_Then_No_Exception()
        {
            // Arrange
            _mockRepository.Setup(x => x.CreateCategory(It.IsAny<Category>()));
            var newCategoryDTO = new NewCategoryDTO() { Name = "Test" };

            // Act
            await _categoriesService.CreateCategory(newCategoryDTO);
        }

        [Fact]
        public async Task Create_Category_With_Null_Name_Then_Throw_NullPropsEntityException()
        {
            // Arrange
            _mockRepository.Setup(x => x.CreateCategory(It.IsAny<Category>()));
            var newCategoryDTO = new NewCategoryDTO() { };

            // Act
            await Assert.ThrowsAsync<NullPropsEntityException>(() =>
                _categoriesService.CreateCategory(newCategoryDTO));
        }

        [Fact]
        public async Task Update_Category_Then_No_Exception()
        {
            // Arrange
            _mockRepository.Setup(x => x.UpdateCategory(It.IsAny<Category>()));
            _mockRepository.Setup(x => x.GetCategoryItem(It.Is<string>(s => s.Equals("1"))))
                .ReturnsAsync(new Category() { Id = "1", Name = "Test" });
            var categoryDTO = new CategoryDTO() { Id="1", Name = "Test" };

            // Act
            await _categoriesService.UpdateCategory(categoryDTO);
        }

        [Theory]
        [InlineData("1", null)]
        [InlineData("2", null)]
        [InlineData(null, "Test")]
        [InlineData(null, null)]
        public async Task Update_Category_With_Wrong_Data_Then_Throw_NullPropsEntityException(string id, string name)
        {
            await Assert.ThrowsAsync<NullPropsEntityException>(() =>
                _categoriesService.UpdateCategory(new CategoryDTO() 
                {
                    Id = id,
                    Name = name
                }));
        }
    }
}
