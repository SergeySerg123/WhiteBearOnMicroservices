using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.Entities;

namespace WhiteBear.Services.Catalog.Api.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<Category[]> GetCategories();
        Task<Category> GetCategoryItem(string id);
        Task CreateCategory(Category item);
        Task UpdateCategory(Category item);
        Task DeleteCategory(Category item);
    }
}
