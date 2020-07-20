using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.Context;
using WhiteBear.Services.Catalog.Api.Data.Entities;
using WhiteBear.Services.Catalog.Api.Data.Entities.Abstraction;
using WhiteBear.Services.Catalog.Api.Repositories.Abstract;
using WhiteBear.Services.Catalog.Api.Repositories.Interfaces;

namespace WhiteBear.Services.Catalog.Api.Repositories
{
    public class CategoriesRepository : BaseRepository<BaseEntity>, 
        ICategoriesRepository
    {
        public CategoriesRepository(CatalogContext context) : base(context)
        {
        }

        public async Task<Category[]> GetCategories()
        {
            return await _context.Categories
                .Include(c => c.Brands)
                .AsNoTracking()
                .ToArrayAsync();
        }

        public async Task<Category> GetCategoryItem(string id)
        {
            return await _context.Categories
                    .Include(c => c.ProductItems)
                    .Include(c => c.Brands)
                    .SingleOrDefaultAsync(c => c.Id == id);
        }


        public async Task CreateCategory(Category item)
        {
            await base.CreateEntity(item);
        }

        public async Task UpdateCategory(Category item)
        {
            await base.UpdateEntity(item);
        }

        public async Task DeleteCategory(Category item)
        {
            await base.DeleteEntity(item);
        }   
    }
}
