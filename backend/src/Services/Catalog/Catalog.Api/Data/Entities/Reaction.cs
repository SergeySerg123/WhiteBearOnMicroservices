using WhiteBear.Services.Catalog.Api.Data.Entities.Abstraction;

namespace WhiteBear.Services.Catalog.Api.Data.Entities
{
    public sealed class Reaction : BaseEntity
    {
        public int Value { get; set; }
        public string ProductItemId { get; set; }
        public ProductItem ProductItem { get; set; }
    }
}
