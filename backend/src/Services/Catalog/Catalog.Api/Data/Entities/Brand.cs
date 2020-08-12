using System.Collections.Generic;
using WhiteBear.Services.Catalog.Api.Data.Entities.Abstraction;

namespace WhiteBear.Services.Catalog.Api.Data.Entities
{
    public sealed class Brand : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Product> ProductItems { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
