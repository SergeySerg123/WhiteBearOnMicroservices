//using AutoMapper;
//using Moq;
//using System.Threading.Tasks;
//using WhiteBear.Services.Catalog.Api.Data.Entities;
//using WhiteBear.Services.Catalog.Api.Data.MappingProfiles;
//using WhiteBear.Services.Catalog.Api.Repositories.Interfaces;
//using WhiteBear.Services.Catalog.Api.Services;
//using Xunit;

//namespace Catalog.Api.Tests.Services
//{
//    public class ProductsServiceTests
//    {
//        private readonly Mock<IProductsRepository> _mockRepository;
//        private readonly IMapper _mapper;
//        private readonly ProductsService _productsService;

//        public ProductsServiceTests()
//        {
//            _mockRepository = new Mock<IProductsRepository>();

//            var mockMapper = new MapperConfiguration(cfg =>
//            {
//                cfg.AddProfile(new ProductProfile());
//            });

//            _mapper = mockMapper.CreateMapper();
//            _productsService = new ProductsService(_mockRepository.Object, _mapper);
//        }

//        [Fact]
//        public async Task Get_Products_Then_Return_Product_Array()
//        {
//            // Arrange
//            _mockRepository.Setup(x => x.GetProducts())
//                .ReturnsAsync(new ProductItem[] {
//                    new ProductItem() { Id="1", Name = "Test", CategoryId="1", BrandId="1" },
//                    new ProductItem() { Id="2", Name = "Test-2", CategoryId="1", BrandId="1" }
//                });

//            // Act 
//            var brands = await _productsService.GetBrands();

//            // Assert
//            Assert.IsType<Brand[]>(brands);
//            Assert.NotNull(brands);
//        }

//        [Fact]
//        public async Task Get_Exist_Brand_Item_Then_Return_Brand()
//        {
//            // Arrange
//            _mockRepository.Setup(x => x.GetBrandItem(It.IsAny<string>()))
//                .ReturnsAsync(new Brand() { Id = "1", Name = "Test", CategoryId = "1" });

//            // Act 
//            var brand = await _productsService.GetBrandById("1");

//            // Assert
//            Assert.IsType<Brand>(brand);
//            Assert.NotNull(brand);
//        }

//        [Fact]
//        public async Task Get_Unexist_Brand_Item_Then_Throw_NotFoundEntityException()
//        {
//            // Arrange
//            _mockRepository.Setup(x => x.GetBrandItem(It.Is<string>(s => s.Equals("1"))))
//                .ReturnsAsync(new Brand() { Id = "1", Name = "Test", CategoryId = "1" });

//            // Act and Assert 
//            await Assert.ThrowsAsync<NotFoundEntityException>(() =>
//                _productsService.GetBrandById("0"));
//        }

//        [Fact]
//        public async Task Create_Brand_Then_No_Exception()
//        {
//            // Arrange
//            _mockRepository.Setup(x => x.CreateBrand(It.IsAny<Brand>()));
//            var newBrandDTO = new NewBrandDTO() { Name = "Test", CategoryId = "1" };

//            // Act
//            await _productsService.CreateBrand(newBrandDTO);
//        }

//        [Theory]
//        [InlineData("Test", null)]
//        [InlineData(null, "1")]
//        [InlineData(null, null)]
//        public async Task Create_Brand_With_Wrong_Params_Then_Throw_NullPropsEntityException(string id, string name)
//        {
//            // Arrange
//            _mockRepository.Setup(x => x.CreateBrand(It.IsAny<Brand>()));
//            var newBrandDTO = new NewBrandDTO() { Name = name, CategoryId = id };

//            // Act
//            await Assert.ThrowsAsync<NullPropsEntityException>(() =>
//                _productsService.CreateBrand(newBrandDTO));
//        }

//        [Fact]
//        public async Task Update_Brand_Then_No_Exception()
//        {
//            // Arrange
//            _mockRepository.Setup(x => x.UpdateBrand(It.IsAny<Brand>()));
//            _mockRepository.Setup(x => x.GetBrandItem(It.Is<string>(s => s.Equals("1"))))
//                .ReturnsAsync(new Brand() { Id = "1", Name = "Test", CategoryId = "1" });
//            var brandDTO = new BrandDTO() { Id = "1", Name = "Test" };

//            // Act
//            await _productsService.UpdateBrand(brandDTO);
//        }

//        [Theory]
//        [InlineData("1", null)]
//        [InlineData(null, "Test")]
//        [InlineData(null, null)]
//        public async Task Update_Brand_With_Wrong_Data_Then_Throw_NullPropsEntityException(string id, string name)
//        {
//            await Assert.ThrowsAsync<NullPropsEntityException>(() =>
//                _productsService.UpdateBrand(new BrandDTO()
//                {
//                    Id = id,
//                    Name = name
//                }));
//        }

//        [Theory]
//        [InlineData("1")]
//        public async Task Delete_Brand_With_Exist_Id_Then_No_Exception(string id)
//        {
//            _mockRepository.Setup(x => x.UpdateBrand(It.IsAny<Brand>()));
//            _mockRepository.Setup(x => x.GetBrandItem(It.Is<string>(s => s.Equals("1"))))
//                .ReturnsAsync(new Brand() { Id = "1", Name = "Test", CategoryId = "1" });

//            await _productsService.DeleteBrand(id);
//        }

//        [Theory]
//        [InlineData("2")]
//        public async Task Delete_Brand_With_Wrong_Id_Then_Throw_NotFoundEntityException(string id)
//        {
//            await Assert.ThrowsAsync<NotFoundEntityException>(() =>
//                _productsService.DeleteBrand(id));
//        }

//        [Theory]
//        [InlineData(null)]
//        public async Task Delete_Brand_With_Null_Id_Then_Throw_NotFoundEntityException(string id)
//        {
//            await Assert.ThrowsAsync<NullPropsEntityException>(() =>
//                _productsService.DeleteBrand(id));
//        }
//    }
//}
