using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WhiteBear.Services.Catalog.Api.Data.Entities.Abstraction;

namespace WhiteBear.Services.Catalog.Api.Data.Entities
{
    public sealed class Brand : BaseEntity
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        public string ProductItemId { get; set; }
        public ICollection<Product> ProductItems { get; set; }
        [Required]
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
