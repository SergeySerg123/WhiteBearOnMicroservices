using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.DTO.Category;
using WhiteBear.Services.Catalog.Api.Services.Interfaces;

namespace WhiteBear.Services.Catalog.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        //GET: api/categories/items
        [HttpGet]
        [Route("items")]
        public async Task<ActionResult> GetCategories()
        {
            var categories = await _categoriesService.GetCategories();
            return Ok(categories);
        }

        //GET: api/categories/items/{id}
        [HttpGet]
        [Route("items/{id}")]
        public async Task<ActionResult> GetCategoryById(string id)
        {
            var category = await _categoriesService.GetCategoryById(id);
            return Ok(category);
        }

        //POST: api/categories/items
        [HttpPost]
        [Route("items")]
        public async Task<ActionResult> CreateCategory(NewCategoryDTO newCategoryDTO)
        {
            await _categoriesService.CreateCategory(newCategoryDTO);
            return Ok();
        }

        //PUT: api/categories/items
        [HttpPut]
        [Route("items")]
        public async Task<ActionResult> UpdateCategory(CategoryDTO categoryDTO)
        {
            await _categoriesService.UpdateCategory(categoryDTO);
            return Ok();
        }

        //DELETE: api/categories/items/{id}
        [HttpDelete]
        [Route("items/{id}")]
        public async Task<ActionResult> DeleteCategory(string id)
        {
            await _categoriesService.DeleteCategory(id);
            return NoContent();
        }
    }
}