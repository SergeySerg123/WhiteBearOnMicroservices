using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.Entities;

namespace WhiteBear.Services.Catalog.Api.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<Category[]> GetCategories();
        Task<Category> GetCategoryItem(string id);
        Task<Category> CreateCategory(Category item);
        Task<Category> UpdateCategory(Category item);
        Task<Category> DeleteCategory(Category item);
    }
}
