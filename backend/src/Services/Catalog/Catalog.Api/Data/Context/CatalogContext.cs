using Microsoft.EntityFrameworkCore;

namespace WhiteBear.Services.Catalog.Api.Data.Context
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base (options)
        {

        }

        
    }
}
