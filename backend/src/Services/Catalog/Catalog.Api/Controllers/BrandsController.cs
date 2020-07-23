using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.DTO.Brand;
using WhiteBear.Services.Catalog.Api.Services;

namespace WhiteBear.Services.Catalog.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Brands")]
    public class BrandsController : Controller
    {
        private readonly BrandsService _brandsService;

        public BrandsController(BrandsService brandsService)
        {
            _brandsService = brandsService;
        }

        //GET: api/brands/items
        [HttpGet]
        [Route("items")]
        public async Task<IActionResult> GetBrands()
        {
            var brands = await _brandsService.GetBrands();
            return Ok(brands);
        }

        //GET: api/brands/items/{id}
        [HttpGet]
        [Route("items/{id}")]
        public async Task<IActionResult> GetBrandById(string id)
        {
            var brand = await _brandsService.GetBrandById(id);
            return Ok(brand);
        }

        //POST: api/brands/items
        [HttpPost]
        [Route("items")]
        public async Task<IActionResult> CreateBrand(NewBrandDTO newBrandDTO)
        {
            await _brandsService.CreateBrand(newBrandDTO);
            return Ok();
        }

        //PUT: api/brands/items
        [HttpPut]
        [Route("items")]
        public async Task<IActionResult> UpdateBrand(BrandDTO brandDTO)
        {
            await _brandsService.UpdateBrand(brandDTO);
            return Ok();
        }

        //DELETE: api/brands/items/{id}
        [HttpDelete]
        [Route("items/{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _brandsService.DeleteBrand(id);
            return NoContent();
        }
    }
}