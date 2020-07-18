using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.DTO.Category;
using WhiteBear.Services.Catalog.Api.Services;

namespace WhiteBear.Services.Catalog.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private readonly CategoriesService _categoriesService;

        public CategoriesController(CategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        //GET: api/categories/items
        [HttpGet]
        [Route("items")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoriesService.GetCategories();
            return Ok(categories);
        }

        //GET: api/categories/items/{id}
        [HttpGet]
        [Route("items/{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var category = await _categoriesService.GetCategoryById(id);
            return Ok(category);
        }

        //POST: api/categories/items
        [HttpPost]
        [Route("items")]
        public async Task<IActionResult> CreateCategory(NewCategoryDTO newCategoryDTO)
        {
            await _categoriesService.CreateCategory(newCategoryDTO);
            return Ok();
        }

        //PUT: api/categories/items
        [HttpPut]
        [Route("items")]
        public async Task<IActionResult> UpdateCategory(CategoryDTO categoryDTO)
        {
            await _categoriesService.UpdateCategory(categoryDTO);
            return Ok();
        }

        //DELETE: api/categories/items/{id}
        [HttpDelete]
        [Route("items/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoriesService.DeleteCategory(id);
            return NoContent();
        }
    }
}