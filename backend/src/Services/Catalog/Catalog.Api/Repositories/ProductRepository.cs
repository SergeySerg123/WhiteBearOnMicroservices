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

            query.Include(p => p.Img)
                .Include(p => p.Reactions)              
                .Skip(pageIndex)
                .Take(pageSize);

            return await query.AsNoTracking().ToArrayAsync();
        }
    }
}
