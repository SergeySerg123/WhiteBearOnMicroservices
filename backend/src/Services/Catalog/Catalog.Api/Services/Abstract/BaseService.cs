using AutoMapper;

namespace WhiteBear.Services.Catalog.Api.Services.Abstract
{
    public abstract class BaseService
    {
        private protected readonly IMapper _mapper;

        public BaseService(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
