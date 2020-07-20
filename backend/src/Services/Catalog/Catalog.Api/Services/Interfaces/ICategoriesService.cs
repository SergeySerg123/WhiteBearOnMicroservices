﻿using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.DTO.Category;
using WhiteBear.Services.Catalog.Api.Data.Entities;

namespace WhiteBear.Services.Catalog.Api.Services.Interfaces
{
    public interface ICategoriesService
    {
        Task<Category[]> GetCategories();
        Task<Category> GetCategoryById(string id);
        Task CreateCategory(NewCategoryDTO newCategoryDTO);
        Task UpdateCategory(CategoryDTO categoryDTO);
        Task DeleteCategory(string id);
    }
}
