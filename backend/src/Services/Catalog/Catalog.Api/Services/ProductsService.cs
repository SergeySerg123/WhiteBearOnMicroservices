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

        public async Task CreateProduct(NewProductItemDTO newProductItemDTO)
        {
            var type = GetEnumBeerTypeFromIntType(newProductItemDTO.BeerType);
            var productItem = new ProductItem()
            {
                Name = newProductItemDTO.Name,
                Description = newProductItemDTO.Description,
                Discount = newProductItemDTO.Discount,
                Price = newProductItemDTO.Price,
                BeerType = type,
                Density = newProductItemDTO.Density,
                CategoryId = newProductItemDTO.CategoryId,
                BrandId = newProductItemDTO.BrandId,
                PreviewImgUrl = newProductItemDTO.PreviewImgUrl
            };
            await _productsRepository.CreateProduct(productItem);
        }

        public async Task UpdateProduct(ProductItemDTO productItemDTO)
        {
            var productItem = _mapper.Map<ProductItem>(productItemDTO);
            var oldProductItem = await _productsRepository.GetProductItem(productItem.Id);

            oldProductItem.Name = productItem.Name;
            oldProductItem.Description = productItem.Description;
            oldProductItem.Discount = productItem.Discount;
            oldProductItem.Price = productItem.Price;
            oldProductItem.BeerType = productItem.BeerType;
            oldProductItem.Density = productItem.Density;
            oldProductItem.PreviewImgUrl = productItem.PreviewImgUrl;
            oldProductItem.CategoryId = productItem.CategoryId;
            oldProductItem.BrandId = productItem.BrandId;

            await _productsRepository.UpdateProduct(oldProductItem);
        }

        public async Task DeleteProduct(string id)
        {
            var oldProductItem = await _productsRepository.GetProductItem(id);
            await _productsRepository.DeleteProduct(oldProductItem);
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
