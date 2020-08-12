using AutoMapper;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.DTO.Category;
using WhiteBear.Services.Catalog.Api.Data.Entities;
using WhiteBear.Services.Catalog.Api.Infrastructure.Exceptions;
using WhiteBear.Services.Catalog.Api.Repositories.Interfaces;
using WhiteBear.Services.Catalog.Api.Services.Abstract;
using WhiteBear.Services.Catalog.Api.Services.Interfaces;

namespace WhiteBear.Services.Catalog.Api.Services
{
    public class CategoriesService : BaseService, ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesService(ICategoriesRepository categoriesRepository, IMapper mapper) : base(mapper) 
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<CategoryDTO[]> GetCategories()
        {
            var categories = await _categoriesRepository.GetCategories();
            return _mapper.Map<CategoryDTO[]>(categories);
        }

        public async Task<CategoryDTO> GetCategoryById(string id)
        {
            var category = await _categoriesRepository.GetCategoryItem(id);
            if (category == null)
            {
                throw new NotFoundEntityException($"Category with id: {id} not found.");
            }
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task CreateCategory(NewCategoryDTO newCategoryDTO)
        {
            var category = _mapper.Map<Category>(newCategoryDTO);
            
            if(category.Name == null)
            {
                throw new NullPropsEntityException("Property 'Name' can't be a null.");
            }

            await _categoriesRepository.CreateCategory(category);
        }

        public async Task UpdateCategory(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);

            if (category.Id == null || category.Name == null)
            {
                throw new NullPropsEntityException("Properties 'Id' and 'Name' can't be a null.");
            }

            var oldCategory = await _categoriesRepository.GetCategoryItem(category.Id);
            
            oldCategory.Name = category.Name;
            oldCategory.UpdatedAt = category.CreatedAt;

            await _categoriesRepository.UpdateCategory(oldCategory);
        }

        public async Task DeleteCategory(string id)
        {
            if (id == null)
            {
                throw new NullPropsEntityException("Property 'id' can't be a null.");
            }
            var oldCategory = await _categoriesRepository.GetCategoryItem(id);

            if (oldCategory == null)
            {
                throw new NotFoundEntityException($"Category with id: {id} not found.");
            }

            await _categoriesRepository.DeleteCategory(oldCategory);
        }
    }
}
