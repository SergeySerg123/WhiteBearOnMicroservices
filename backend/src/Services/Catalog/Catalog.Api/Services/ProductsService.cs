using AutoMapper;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.DTO.ProductItem;
using WhiteBear.Services.Catalog.Api.Data.Entities;
using WhiteBear.Services.Catalog.Api.Infrastructure.Exceptions;
using WhiteBear.Services.Catalog.Api.Repositories.Interfaces;
using WhiteBear.Services.Catalog.Api.Services.Abstract;

namespace WhiteBear.Services.Catalog.Api.Services
{
    public class ProductsService : BaseService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository, IMapper mapper) : base(mapper)
        {
            _productsRepository = productsRepository;
        }

        public async Task<ProductItemDTO[]> GetProducts(string categoryId, string brandId, int type,
            int pageSize, int pageIndex)
        {
            EnumBeerTypes beerType = GetEnumBeerTypeFromIntType(type);
            var products = await _productsRepository.GetProducts(categoryId, brandId, beerType, pageSize, pageIndex);
            return _mapper.Map<ProductItemDTO[]>(products);
        }

        private EnumBeerTypes GetEnumBeerTypeFromIntType(int type)
        {
            switch(type)
            {
                case 0:
                    return EnumBeerTypes.White;
                case 1:
                    return EnumBeerTypes.Dark;
                case 2:
                    return EnumBeerTypes.Unfiltered;
                default:
                    throw new CastEnumBeerTypeException();
            }
        }
    }
}
