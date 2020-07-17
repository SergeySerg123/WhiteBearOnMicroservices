using WhiteBear.Services.Catalog.Api.Data.Context;

namespace WhiteBear.Services.Catalog.Api.Repositories.Abstract
{
    public class BaseRepository
    {
        private protected readonly CatalogContext _context;

        public BaseRepository(CatalogContext context)
        {
            _context = context;
        }
    }
}
