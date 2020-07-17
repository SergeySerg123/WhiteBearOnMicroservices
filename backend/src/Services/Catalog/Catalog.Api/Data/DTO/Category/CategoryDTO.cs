using System.Collections.Generic;
using WhiteBear.Services.Catalog.Api.Data.DTO.Brand;

namespace WhiteBear.Services.Catalog.Api.Data.DTO.Category
{
    public sealed class CategoryDTO
    {
        public string Name { get; set; }
        public ICollection<BrandDTO> Brands { get; set; } 
    }
}
