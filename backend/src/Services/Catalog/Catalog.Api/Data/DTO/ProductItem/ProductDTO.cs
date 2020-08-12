using System.Collections.Generic;
using WhiteBear.Services.Catalog.Api.Data.DTO.Brand;
using WhiteBear.Services.Catalog.Api.Data.DTO.Category;
using WhiteBear.Services.Catalog.Api.Data.DTO.Reaction;

namespace WhiteBear.Services.Catalog.Api.Data.DTO.ProductItem
{
    public sealed class ProductDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Discount { get; set; } = 0.0;
        public decimal Price { get; set; }
        public int BeerType { get; set; }
        public double Density { get; set; }
        public string PreviewImg { get; set; }
        public CategoryDTO Category { get; set; }
        public BrandDTO Brand { get; set; }
        public ICollection<ReactionDTO> Reaction { get; set; }
    }
}
