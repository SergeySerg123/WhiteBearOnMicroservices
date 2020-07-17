using System.Collections.Generic;
using WhiteBear.Services.Catalog.Api.Data.Entities.Abstraction;

namespace WhiteBear.Services.Catalog.Api.Data.Entities
{
    public sealed class ProductItem : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Discount { get; set; }
        public decimal Price { get; set; }
        public EnumBeerTypes BeerType { get; set; }
        public double Density { get; set; } 
        public string ImageId { get; set; }
        public Image PreviewImg { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public string BrandId { get; set; }
        public Brand Brand { get; set; }
        public string ReactionId { get; set; }
        public ICollection<Reaction> Reactions { get; set; }
    }
}
