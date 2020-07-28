using AutoMapper;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.DTO.ProductItem;
using WhiteBear.Services.Catalog.Api.Data.Entities;
using static WhiteBear.Services.Catalog.Api.Extensions.Utils;
using WhiteBear.Services.Catalog.Api.Repositories.Interfaces;
using WhiteBear.Services.Catalog.Api.Services.Abstract;
using WhiteBear.Services.Catalog.Api.Enums;
using WhiteBear.Services.Catalog.Api.Infrastructure.Exceptions;

namespace WhiteBear.Services.Catalog.Api.Services
{
    public class ProductsService : BaseService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository, IMapper mapper) : base(mapper)
        {
            _productsRepository = productsRepository;
        }

        public async Task<ProductDTO[]> GetProducts(string categoryId, string brandId, int type,
            int pageSize, int pageIndex)
        {
            EnumBeerTypes beerType = GetEnumBeerTypeFromIntType(type);
            var products = await _productsRepository.GetProducts(categoryId, brandId, beerType, pageSize, pageIndex);
            if (products == null)
            {
                throw new NotFoundEntityException("No products");
            }
            return _mapper.Map<ProductDTO[]>(products);
        }

        public async Task<ProductDTO> GetProduct(string id)
        {
            var product = await _productsRepository.GetProductItem(id);
            if (product == null)
            {
                throw new NotFoundEntityException($"product with id '{id}' was not found.");
            }
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task CreateProduct(NewProductDTO newProductItemDTO)
        {
            var productItem = _mapper.Map<Product>(newProductItemDTO);
            if (productItem.Name == null || productItem.CategoryId == null || productItem.BrandId == null)
            {
                throw new NullPropsEntityException("Properties 'Name, CategoryId, BrandId' can't be a null.");
            }
            await _productsRepository.CreateProduct(productItem);
        }

        public async Task UpdateProduct(ProductDTO productItemDTO)
        {
            var productItem = _mapper.Map<Product>(productItemDTO);
            var oldProductItem = await _productsRepository.GetProductItem(productItem.Id);

            if (productItem.Id == null || productItem.Name == null || productItem.CategoryId == null || productItem.BrandId == null)
            {
                throw new NullPropsEntityException("Properties 'Id, Name, CategoryId, BrandId' can't be a null.");
            }

            oldProductItem.Name = productItem.Name;
            oldProductItem.Description = productItem.Description;
            oldProductItem.Discount = productItem.Discount;
            oldProductItem.Price = productItem.Price;
            oldProductItem.BeerType = productItem.BeerType;
            oldProductItem.Density = productItem.Density;
            oldProductItem.PreviewImg = productItem.PreviewImg;
            oldProductItem.CategoryId = productItem.CategoryId;
            oldProductItem.BrandId = productItem.BrandId;
            oldProductItem.UpdatedAt = productItem.CreatedAt;

            await _productsRepository.UpdateProduct(oldProductItem);
        }

        public async Task DeleteProduct(string id)
        {
            var oldProductItem = await _productsRepository.GetProductItem(id);
            await _productsRepository.DeleteProduct(oldProductItem);
        }        
    }
}
