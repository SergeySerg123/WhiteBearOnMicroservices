using AutoMapper;
using WhiteBear.Services.Catalog.Api.Repositories.Interfaces;
using WhiteBear.Services.Catalog.Api.Services.Abstract;

namespace WhiteBear.Services.Catalog.Api.Services
{
    public class CategoriesService : BaseService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesService(ICategoriesRepository categoriesRepository, IMapper mapper) : base(mapper) 
        {
            _categoriesRepository = categoriesRepository;
        }


    }
}
