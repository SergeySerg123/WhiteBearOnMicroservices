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
                    .SingleAsync(c => c.Id == id);
        }


        public async Task<Category> CreateCategory(Category item)
        {
            return await base.CreateEntity(item) as Category;
        }

        public async Task<Category> UpdateCategory(Category item)
        {
            return await base.UpdateEntity(item) as Category;
        }

        public async Task<Category> DeleteCategory(Category item)
        {
            return await base.DeleteEntity(item) as Category;
        }   
    }
}
