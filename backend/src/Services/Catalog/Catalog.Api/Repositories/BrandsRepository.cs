using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.Context;
using WhiteBear.Services.Catalog.Api.Data.Entities;
using WhiteBear.Services.Catalog.Api.Data.Entities.Abstraction;
using WhiteBear.Services.Catalog.Api.Repositories.Abstract;
using WhiteBear.Services.Catalog.Api.Repositories.Interfaces;

namespace WhiteBear.Services.Catalog.Api.Repositories
{
    public class BrandsRepository : BaseRepository<BaseEntity>,
        IBrandsRepository
    {
        public BrandsRepository(CatalogContext context) : base(context)
        {
        }

        public async Task<Brand[]> GetBrands()
        {
            return await _context.Brands
                .Include(b => b.ProductItems)
                .Include(b => b.Category)
                .AsNoTracking()
                .ToArrayAsync();
        }

        public async Task<Brand> GetBrandItem(string id)
        {
            return await _context.Brands
                    .Include(c => c.ProductItems)
                    .Include(c => c.Category)
                    .SingleAsync(c => c.Id == id);
        }
       
        public async Task CreateBrand(Brand item)
        {
            await base.CreateEntity(item);
        }

        public async Task UpdateBrand(Brand item)
        {
            await base.UpdateEntity(item);
        }

        public async Task DeleteBrand(Brand item)
        {
            await base.DeleteEntity(item);
        }
    }
}
