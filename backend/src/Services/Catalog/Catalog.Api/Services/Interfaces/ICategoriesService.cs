using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.DTO.Category;

namespace WhiteBear.Services.Catalog.Api.Services.Interfaces
{
    public interface ICategoriesService
    {
        Task<CategoryDTO[]> GetCategories();
        Task<CategoryDTO> GetCategoryById(string id);
        Task CreateCategory(NewCategoryDTO newCategoryDTO);
        Task UpdateCategory(CategoryDTO categoryDTO);
        Task DeleteCategory(string id);
    }
}
