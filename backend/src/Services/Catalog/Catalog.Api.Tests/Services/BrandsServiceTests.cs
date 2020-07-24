using AutoMapper;
using Moq;
using System;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.DTO.Brand;
using WhiteBear.Services.Catalog.Api.Data.Entities;
using WhiteBear.Services.Catalog.Api.Data.MappingProfiles;
using WhiteBear.Services.Catalog.Api.Infrastructure.Exceptions;
using WhiteBear.Services.Catalog.Api.Repositories.Interfaces;
using WhiteBear.Services.Catalog.Api.Services;
using Xunit;

namespace Catalog.Api.Tests.Services
{
    public class BrandsServiceTests
    {
        private readonly Mock<IBrandsRepository> _mockRepository;
        private readonly IMapper _mapper;
        private readonly BrandsService _brandsService;

        public BrandsServiceTests()
        {
            _mockRepository = new Mock<IBrandsRepository>();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BrandProfile());
            });

            _mapper = mockMapper.CreateMapper();
            _brandsService = new BrandsService(_mockRepository.Object, _mapper);
        }

        [Fact]
        public async Task Get_Brands_Then_Return_Brand_Array()
        {
            // Arrange
            _mockRepository.Setup(x => x.GetBrands())
                .ReturnsAsync(new Brand[] {
                    new Brand() { Id="1", Name = "Test", CategoryId="1" },
                    new Brand() { Id="2", Name = "Test-2", CategoryId="1" }
                });

            // Act 
            var brands = await _brandsService.GetBrands();

            // Assert
            Assert.IsType<Brand[]>(brands);
            Assert.NotNull(brands);
        }

        [Fact]
        public async Task Get_Exist_Brand_Item_Then_Return_Brand()
        {
            // Arrange
            _mockRepository.Setup(x => x.GetBrandItem(It.IsAny<string>()))
                .ReturnsAsync(new Brand() { Id = "1", Name = "Test", CategoryId = "1" });

            // Act 
            var brand = await _brandsService.GetBrandById("1");

            // Assert
            Assert.IsType<Brand>(brand);
            Assert.NotNull(brand);
        }

        [Fact]
        public async Task Get_Unexist_Brand_Item_Then_Throw_NotFoundEntityException()
        {
            // Arrange
            _mockRepository.Setup(x => x.GetBrandItem(It.Is<string>(s => s.Equals("1"))))
                .ReturnsAsync(new Brand() { Id = "1", Name = "Test", CategoryId = "1" });

            // Act and Assert 
            await Assert.ThrowsAsync<NotFoundEntityException>(() =>
                _brandsService.GetBrandById("0"));
        }

        [Fact]
        public async Task Create_Brand_Then_No_Exception()
        {
            // Arrange
            _mockRepository.Setup(x => x.CreateBrand(It.IsAny<Brand>()));
            var newBrandDTO = new NewBrandDTO() { Name = "Test", CategoryId = "1" };

            // Act
            await _brandsService.CreateBrand(newBrandDTO);
        }

        [Theory]
        [InlineData("Test", null)]
        [InlineData(null, "1")]
        [InlineData(null, null)]
        public async Task Create_Brand_With_Null_Params_Then_Throw_NullPropsEntityException(string name, string id)
        {
            // Arrange
            _mockRepository.Setup(x => x.CreateBrand(It.IsAny<Brand>()));
            var newBrandDTO = new NewBrandDTO() { Name = name, CategoryId = id };

            // Act
            await Assert.ThrowsAsync<NullPropsEntityException>(() =>
                _brandsService.CreateBrand(newBrandDTO));
        }

        [Fact]
        public async Task Update_Brand_Then_No_Exception()
        {
            // Arrange
            _mockRepository.Setup(x => x.UpdateBrand(It.IsAny<Brand>()));
            _mockRepository.Setup(x => x.GetBrandItem(It.Is<string>(s => s.Equals("1"))))
                .ReturnsAsync(new Brand() { Id = "1", Name = "Test", CategoryId = "1" });
            var brandDTO = new BrandDTO() { Id = "1", Name = "Test" };

            // Act
            await _brandsService.UpdateBrand(brandDTO);
        }

        [Theory]
        [InlineData("1", null)]
        [InlineData(null, "Test")]
        [InlineData(null, null)]
        public async Task Update_Brand_With_Wrong_Data_Then_Throw_NullPropsEntityException(string id, string name)
        {
            await Assert.ThrowsAsync<NullPropsEntityException>(() =>
                _brandsService.UpdateBrand(new BrandDTO()
                {
                    Id = id,
                    Name = name
                }));
        }

        [Theory]
        [InlineData("1")]
        public async Task Delete_Brand_With_Exist_Id_Then_No_Exception(string id)
        {
            _mockRepository.Setup(x => x.UpdateBrand(It.IsAny<Brand>()));
            _mockRepository.Setup(x => x.GetBrandItem(It.Is<string>(s => s.Equals("1"))))
                .ReturnsAsync(new Brand() { Id = "1", Name = "Test", CategoryId = "1" });

            await _brandsService.DeleteBrand(id);
        }

        [Theory]
        [InlineData("2")]
        public async Task Delete_Brand_With_Wrong_Id_Then_Throw_NotFoundEntityException(string id)
        {
            await Assert.ThrowsAsync<NotFoundEntityException>(() =>
                _brandsService.DeleteBrand(id));
        }

        [Theory]
        [InlineData(null)]
        public async Task Delete_Brand_With_Null_Id_Then_Throw_NotFoundEntityException(string id)
        {
            await Assert.ThrowsAsync<NullPropsEntityException>(() =>
                _brandsService.DeleteBrand(id));
        }
    }
}
