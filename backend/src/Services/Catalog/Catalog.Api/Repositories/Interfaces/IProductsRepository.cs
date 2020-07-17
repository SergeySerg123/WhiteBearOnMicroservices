using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.Entities;

namespace WhiteBear.Services.Catalog.Api.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        Task<ProductItem[]> GetProducts(string categoryId, string brandId, EnumBeerTypes type, int pageSize,int pageIndex);
        Task<ProductItem> GetProductItem(string id);
        Task CreateProduct(ProductItem item);
        Task UpdateProduct(ProductItem item);
        Task DeleteProduct(ProductItem item);
    }
}
