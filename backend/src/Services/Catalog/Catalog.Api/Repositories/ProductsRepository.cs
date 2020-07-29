using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.Context;
using WhiteBear.Services.Catalog.Api.Data.Entities;
using WhiteBear.Services.Catalog.Api.Data.Entities.Abstraction;
using WhiteBear.Services.Catalog.Api.Enums;
using WhiteBear.Services.Catalog.Api.Repositories.Abstract;
using WhiteBear.Services.Catalog.Api.Repositories.Interfaces;

namespace WhiteBear.Services.Catalog.Api.Repositories
{
    public class ProductsRepository : BaseRepository<BaseEntity>, IProductsRepository
    {
        public ProductsRepository(CatalogContext context) : base(context) { }

        public async Task<Product[]> GetProducts(string categoryId, string brandId, EnumBeerTypes type,
            int pageSize, int pageIndex)
        {
            IQueryable<Product> query = _context.ProductItems;
            
            if(categoryId != null)
            {
                query = query.Where(p => p.Category.Id == categoryId);
            }

            if(brandId != null)
            {
                query = query.Where(p => p.Brand.Id == brandId);
            }

            if (type != EnumBeerTypes.All)
            {
                query = query.Where(p => p.BeerType == type);
            }

            var items = await query.Include(p => p.Reactions)  
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.PreviewImg)
                .Skip(pageIndex)
                .Take(pageSize)
                .AsNoTracking()
                .ToArrayAsync();

            return items;
        }

        public async Task<Product> GetProductItem(string id)
        {
            return await _context.ProductItems.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateProduct(Product item)
        {
            await base.CreateEntity(item);
        }

        public async Task UpdateProduct(Product item)
        {
            await base.UpdateEntity(item);
        }      

        public async Task DeleteProduct(Product item)
        {
            await base.DeleteEntity(item);
        }
    }
}
