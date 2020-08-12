using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.Entities;
using WhiteBear.Services.Catalog.Api.Enums;

namespace WhiteBear.Services.Catalog.Api.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        Task<Product[]> GetProducts(string categoryId, string brandId, EnumBeerTypes type, int pageSize,int pageIndex);
        Task<Product> GetProductItem(string id);
        Task CreateProduct(Product item);
        Task UpdateProduct(Product item);
        Task DeleteProduct(Product item);
    }
}
