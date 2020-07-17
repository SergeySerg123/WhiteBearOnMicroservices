using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.DTO.ProductItem;
using WhiteBear.Services.Catalog.Api.Services;

namespace WhiteBear.Services.Catalog.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ProductsService _productsService;

        public ProductsController(ProductsService productsService)
        {
            _productsService = productsService;
        }

        //GET: /api/products/items/categories/{categoryId}/brands/{brandId}/types/{type}?pageSize=50&pageIndex=1
        [HttpGet]
        [Route("items/category/{category:string}/brand/{brand:string}/type/{type:int}")]
        public async Task<IActionResult> GetProducts(string categoryId, string brandId, int type,
            [FromQuery] int pageSize = 50, [FromQuery]int pageIndex = 0)
        {
            var products = await _productsService.GetProducts(categoryId, brandId, type, pageSize, pageIndex);
            return Ok(products);
        }

        //POST: /api/products/items
        [HttpPost]
        [Route("items")]
        public async Task<IActionResult> CreateProduct([FromBody]NewProductItemDTO newProductItemDTO)
        {
            if (newProductItemDTO == null)
            {
                return BadRequest();
            }
            await _productsService.CreateProduct(newProductItemDTO);           
            return Ok();
        }

        //PUT: /api/products/items/{id}
        [HttpPut]
        [Route("items/{id:string}")]
        public async Task<IActionResult> UpdateProduct(ProductItemDTO productItemDTO)
        {
            await _productsService.UpdateProduct(productItemDTO);
            return NoContent();
        }

        //DELETE: /api/products/items/{id}
        [HttpDelete]
        [Route("items/{id:string}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productsService.DeleteProduct(id);
            return NoContent();
        }
    }
}