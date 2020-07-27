using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.Entities;

namespace WhiteBear.Services.Catalog.Api.Repositories.Interfaces
{
    public interface IBrandsRepository
    {
        Task<Brand[]> GetBrands();
        Task<Brand> GetBrandItem(string id);
        Task CreateBrand(Brand item);
        Task UpdateBrand(Brand item);
        Task DeleteBrand(Brand item);
    }
}
