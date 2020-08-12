using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.Context;

namespace WhiteBear.Services.Catalog.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Bottles")]
    public class BottlesController : Controller
    {
        private readonly CatalogContext _context;

        public BottlesController(CatalogContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBottles()
        {
            var bottles = await _context.Bottles.ToListAsync();
            return Ok(bottles);
        }
    }
}