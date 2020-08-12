using AutoMapper;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.DTO.Brand;
using WhiteBear.Services.Catalog.Api.Data.Entities;
using WhiteBear.Services.Catalog.Api.Infrastructure.Exceptions;
using WhiteBear.Services.Catalog.Api.Repositories.Interfaces;
using WhiteBear.Services.Catalog.Api.Services.Abstract;

namespace WhiteBear.Services.Catalog.Api.Services
{
    public class BrandsService : BaseService
    {
        private readonly IBrandsRepository _brandsRepository;

        public BrandsService(IBrandsRepository brandsRepository, IMapper mapper) : base(mapper)
        {
            _brandsRepository = brandsRepository;
        }

        public async Task<BrandDTO[]> GetBrands()
        {
            var brands = await _brandsRepository.GetBrands();
            if (brands == null)
            {
                throw new NotFoundEntityException($"No brands.");
            }
            return _mapper.Map<BrandDTO[]>(brands);
        }

        public async Task<BrandDTO> GetBrandById(string id)
        {
            var brand = await _brandsRepository.GetBrandItem(id);
            if (brand == null)
            {
                throw new NotFoundEntityException($"Brand with id: {id} not found.");
            }
            return _mapper.Map<BrandDTO>(brand);
        }

        public async Task CreateBrand(NewBrandDTO newBrandDTO)
        {
            var brand = _mapper.Map<Brand>(newBrandDTO);
            if (brand.Name == null)
            {
                throw new NullPropsEntityException("Property 'Name' can't be a null.");
            }

            if (brand.CategoryId == null)
            {
                throw new NullPropsEntityException("Brand must have categoryId.");
            }
            await _brandsRepository.CreateBrand(brand);
        }

        public async Task UpdateBrand(BrandDTO BrandDTO)
        {
            var brand = _mapper.Map<Brand>(BrandDTO);

            if (brand.Id == null || brand.Name == null)
            {
                throw new NullPropsEntityException("Properties 'Id' and 'Name' can't be a null.");
            }

            var oldBrand = await _brandsRepository.GetBrandItem(brand.Id);

            oldBrand.Name = brand.Name;
            oldBrand.UpdatedAt = brand.CreatedAt;

            await _brandsRepository.UpdateBrand(oldBrand);
        }

        public async Task DeleteBrand(string id)
        {
            if (id == null)
            {
                throw new NullPropsEntityException("Property 'id' can't be a null.");
            }

            var oldBrand = await _brandsRepository.GetBrandItem(id);

            if (oldBrand == null)
            {
                throw new NotFoundEntityException($"Category with id: {id} not found.");
            }
            await _brandsRepository.DeleteBrand(oldBrand);
        }
    }
}
