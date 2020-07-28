using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WhiteBear.Services.Catalog.Api.Data.Entities.Abstraction;
using WhiteBear.Services.Catalog.Api.Enums;

namespace WhiteBear.Services.Catalog.Api.Data.Entities
{
    public sealed class Product : BaseEntity
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Discount { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public EnumBeerTypes BeerType { get; set; }
        public double Density { get; set; } 
        public string ImageId { get; set; }
        public Image PreviewImg { get; set; }
        [Required]
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public string BrandId { get; set; }
        public Brand Brand { get; set; }
        public string ReactionId { get; set; }
        public ICollection<Reaction> Reactions { get; set; }
    }
}
