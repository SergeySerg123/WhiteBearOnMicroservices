using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.Context;
using WhiteBear.Services.Catalog.Api.Data.Entities;
using WhiteBear.Services.Catalog.Api.Repositories.Abstract;
using WhiteBear.Services.Catalog.Api.Repositories.Interfaces;

namespace WhiteBear.Services.Catalog.Api.Repositories
{
    public class ProductRepository : BaseRepository, IProductsRepository
    {
        public ProductRepository(CatalogContext context) : base(context) { }

        public async Task<ProductItem[]> GetProducts(string categoryId, string brandId, EnumBeerTypes type,
            int pageSize, int pageIndex)
        {
            IQueryable<ProductItem> query = _context.ProductItems;
            
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
                .Skip(pageIndex)
                .Take(pageSize)
                .AsNoTracking()
                .ToArrayAsync();

            return items;
        }

        public async Task<ProductItem> GetProductItem(string id)
        {
            return await _context.ProductItems.FirstAsync(p => p.Id == id);
        }

        public async Task CreateProduct(ProductItem item)
        {
            await _context.ProductItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(ProductItem item)
        {
            _context.ProductItems.Update(item);
            await _context.SaveChangesAsync();
        }      

        public async Task DeleteProduct(ProductItem item)
        {
            _context.ProductItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
