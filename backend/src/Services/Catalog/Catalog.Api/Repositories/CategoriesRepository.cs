using WhiteBear.Services.Catalog.Api.Data.Context;
using WhiteBear.Services.Catalog.Api.Repositories.Abstract;
using WhiteBear.Services.Catalog.Api.Repositories.Interfaces;

namespace WhiteBear.Services.Catalog.Api.Repositories
{
    public class CategoriesRepository : BaseRepository, ICategoriesRepository
    {
        public CategoriesRepository(CatalogContext context) : base(context)
        {
        }
    }
}
