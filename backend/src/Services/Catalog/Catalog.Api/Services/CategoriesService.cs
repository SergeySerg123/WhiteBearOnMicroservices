using AutoMapper;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.DTO.Category;
using WhiteBear.Services.Catalog.Api.Data.Entities;
using WhiteBear.Services.Catalog.Api.Repositories.Interfaces;
using WhiteBear.Services.Catalog.Api.Services.Abstract;

namespace WhiteBear.Services.Catalog.Api.Services
{
    public class CategoriesService : BaseService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesService(ICategoriesRepository categoriesRepository, IMapper mapper) : base(mapper) 
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<Category[]> GetCategories()
        {
            return await _categoriesRepository.GetCategories();
        }

        public async Task<Category> GetCategoryById(string id)
        {
            return await _categoriesRepository.GetCategoryItem(id);
        }

        public async Task CreateCategory(NewCategoryDTO newCategoryDTO)
        {
            var category = _mapper.Map<Category>(newCategoryDTO);
            await _categoriesRepository.CreateCategory(category);
        }

        public async Task UpdateCategory(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            var oldCategory = await _categoriesRepository.GetCategoryItem(category.Id);

            oldCategory.Name = category.Name;
            oldCategory.UpdatedAt = category.CreatedAt;

            await _categoriesRepository.UpdateCategory(oldCategory);
        }

        public async Task DeleteCategory(string id)
        {
            var oldCategory = await _categoriesRepository.GetCategoryItem(id);
            await _categoriesRepository.DeleteCategory(oldCategory);
        }
    }
}
