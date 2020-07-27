using AutoMapper;
using Moq;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.DTO.Brand;
using WhiteBear.Services.Catalog.Api.Data.DTO.Category;
using WhiteBear.Services.Catalog.Api.Data.DTO.ProductItem;
using WhiteBear.Services.Catalog.Api.Data.Entities;
using WhiteBear.Services.Catalog.Api.Data.MappingProfiles;
using WhiteBear.Services.Catalog.Api.Enums;
using WhiteBear.Services.Catalog.Api.Infrastructure.Exceptions;
using WhiteBear.Services.Catalog.Api.Repositories.Interfaces;
using WhiteBear.Services.Catalog.Api.Services;
using Xunit;

namespace Catalog.Api.Tests.Services
{
    public class ProductsServiceTests
    {
        private readonly Mock<IProductsRepository> _mockRepository;
        private readonly IMapper _mapper;
        private readonly ProductsService _productsService;

        public ProductsServiceTests()
        {
            _mockRepository = new Mock<IProductsRepository>();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductProfile());
            });

            _mapper = mockMapper.CreateMapper();
            _productsService = new ProductsService(_mockRepository.Object, _mapper);
        }

        [Theory]
        [InlineData(null, null, 3, 50, 0)]
        public async Task Get_Products_Then_Return_Product_Array(string categoryId, string brandId, int type,
            int pageSize, int pageIndex)
        {
            // Arrange
            _mockRepository.Setup(x => x.GetProducts(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<EnumBeerTypes>(),
                It.IsAny<int>(),
                It.IsAny<int>()
                ))
                .ReturnsAsync(new ProductItem[] {
                    new ProductItem() { Id="1", Name = "Test", CategoryId="1", BrandId="1" },
                    new ProductItem() { Id="2", Name = "Test-2", CategoryId="1", BrandId="1" }
                });

            // Act 
            var productItemDTO = await _productsService.GetProducts(categoryId, brandId, type, pageSize, pageIndex);

            // Assert
            Assert.IsType<ProductItemDTO[]>(productItemDTO);
            Assert.NotNull(productItemDTO);
        }

        [Theory]
        [InlineData(null, null, 3, 50, 0)]
        public async Task Get_Products_Then_Throw_NotFoundEntityException(string categoryId, string brandId, int type,
            int pageSize, int pageIndex)
        {
            // Arrange
            _mockRepository.Setup(x => x.GetProducts(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<EnumBeerTypes>(),
                It.IsAny<int>(),
                It.IsAny<int>()
                )).Throws<NotFoundEntityException>();

            // Act 
            await Assert.ThrowsAsync<NotFoundEntityException>(() =>
                _productsService.GetProducts(categoryId, brandId, type, pageSize, pageIndex));
        }

        [Fact]
        public async Task Get_Exist_Product_Then_Return_Product()
        {
            // Arrange
            _mockRepository.Setup(x => x.GetProductItem(It.IsAny<string>()))
                .ReturnsAsync(new ProductItem() { Id = "1", Name = "Test", CategoryId = "1", BrandId = "1" });

            // Act 
            var productDTO = await _productsService.GetProduct("1");

            // Assert
            Assert.IsType<ProductItemDTO>(productDTO);
            Assert.NotNull(productDTO);
        }

        [Fact]
        public async Task Get_Unexist_Product_Then_Throw_NotFoundEntityException()
        {
            // Arrange
            _mockRepository.Setup(x => x.GetProductItem(It.Is<string>(s => s.Equals("1"))))
                .ReturnsAsync(new ProductItem() { Id = "1", Name = "Test", CategoryId = "1", BrandId = "1" });

            // Act and Assert 
            await Assert.ThrowsAsync<NotFoundEntityException>(() =>
                _productsService.GetProduct("0"));
        }

        [Fact]
        public async Task Create_Product_Then_No_Exception()
        {
            // Arrange
            _mockRepository.Setup(x => x.CreateProduct(It.IsAny<ProductItem>()));
            var newProductDTO = new NewProductItemDTO() { Name = "Test", CategoryId = "1", BrandId = "1" };

            // Act
            await _productsService.CreateProduct(newProductDTO);
        }

        [Theory]
        [InlineData("1", "1", null)]
        [InlineData(null, "1", "Test")]
        [InlineData(null, null, "Test")]
        public async Task Create_Product_With_Wrong_Params_Then_Throw_NullPropsEntityException(string categoryId, string brandId, string name)
        {
            // Arrange
            _mockRepository.Setup(x => x.CreateProduct(It.IsAny<ProductItem>()));
            var newProductDTO = new NewProductItemDTO() { Name = name, CategoryId = categoryId, BrandId = brandId };

            // Act
            await Assert.ThrowsAsync<NullPropsEntityException>(() =>
                _productsService.CreateProduct(newProductDTO));
        }

        [Fact]
        public async Task Update_Product_Then_No_Exception()
        {
            // Arrange
            _mockRepository.Setup(x => x.UpdateProduct(It.IsAny<ProductItem>()));
            _mockRepository.Setup(x => x.GetProductItem(It.Is<string>(s => s.Equals("1"))))
                .ReturnsAsync(new ProductItem() { Id = "1", Name = "Test", CategoryId = "1", BrandId = "1" });
            var newProductDTO = new ProductItemDTO() { Name = "Test", Id = "1" };

            // Act
            await Assert.ThrowsAsync<NullPropsEntityException>(() =>
                _productsService.UpdateProduct(newProductDTO));
        }

        [Theory]
        [InlineData(null, "Test")]
        [InlineData("1", null)]
        public async Task Update_Product_With_Wrong_Data_Then_Throw_NullPropsEntityException(string id, string name)
        {
            await Assert.ThrowsAsync<NullPropsEntityException>(() =>
                _productsService.UpdateProduct(new ProductItemDTO()
                {
                    Id = id,
                    Name = name
                }));
        }

            //[Theory]
            //[InlineData("1")]
            //public async Task Delete_Brand_With_Exist_Id_Then_No_Exception(string id)
            //{
            //    _mockRepository.Setup(x => x.UpdateBrand(It.IsAny<Brand>()));
            //    _mockRepository.Setup(x => x.GetBrandItem(It.Is<string>(s => s.Equals("1"))))
            //        .ReturnsAsync(new Brand() { Id = "1", Name = "Test", CategoryId = "1" });

            //    await _productsService.DeleteBrand(id);
            //}

        //    [Theory]
        //    [InlineData("2")]
        //    public async Task Delete_Brand_With_Wrong_Id_Then_Throw_NotFoundEntityException(string id)
        //    {
        //        await Assert.ThrowsAsync<NotFoundEntityException>(() =>
        //            _productsService.DeleteBrand(id));
        //    }

        //    [Theory]
        //    [InlineData(null)]
        //    public async Task Delete_Brand_With_Null_Id_Then_Throw_NotFoundEntityException(string id)
        //    {
        //        await Assert.ThrowsAsync<NullPropsEntityException>(() =>
        //            _productsService.DeleteBrand(id));
        //    }
        //}
    }
}
