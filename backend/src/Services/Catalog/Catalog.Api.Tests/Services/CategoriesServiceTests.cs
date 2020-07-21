using AutoMapper;
using Moq;
using WhiteBear.Services.Catalog.Api.Data.MappingProfiles;
using WhiteBear.Services.Catalog.Api.Repositories.Interfaces;

namespace Catalog.Api.Tests.Services
{
    class CategoriesServiceTests
    {
        private readonly Mock<ICategoriesRepository> _mockRepository;
        private readonly IMapper _mapper;

        public CategoriesServiceTests()
        {
            _mockRepository = new Mock<ICategoriesRepository>();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CategoryProfile());
            });

            _mapper = mockMapper.CreateMapper();
        }
    }
}
