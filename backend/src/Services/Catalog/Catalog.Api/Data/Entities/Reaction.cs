using System.ComponentModel.DataAnnotations;
using WhiteBear.Services.Catalog.Api.Data.Entities.Abstraction;

namespace WhiteBear.Services.Catalog.Api.Data.Entities
{
    public sealed class Reaction : BaseEntity
    {
        public int Value { get; set; }
        [Required]
        public string ProductItemId { get; set; }
        public Product ProductItem { get; set; }
    }
}
