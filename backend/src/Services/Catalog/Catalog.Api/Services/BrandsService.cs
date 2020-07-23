using AutoMapper;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.DTO.Brand;
using WhiteBear.Services.Catalog.Api.Data.Entities;
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

        public async Task<Brand[]> GetBrands()
        {
            return await _brandsRepository.GetBrands();
        }

        public async Task<Brand> GetBrandById(string id)
        {
            return await _brandsRepository.GetBrandItem(id);
        }

        public async Task CreateBrand(NewBrandDTO newBrandDTO)
        {
            var Brand = _mapper.Map<Brand>(newBrandDTO);
            await _brandsRepository.CreateBrand(Brand);
        }

        public async Task UpdateBrand(BrandDTO BrandDTO)
        {
            var brand = _mapper.Map<Brand>(BrandDTO);
            var oldBrand = await _brandsRepository.GetBrandItem(brand.Id);

            oldBrand.Name = brand.Name;
            oldBrand.UpdatedAt = brand.CreatedAt;

            await _brandsRepository.UpdateBrand(oldBrand);
        }

        public async Task DeleteBrand(string id)
        {
            var oldBrand = await _brandsRepository.GetBrandItem(id);
            await _brandsRepository.DeleteBrand(oldBrand);
        }
    }
}
