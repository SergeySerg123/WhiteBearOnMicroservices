using WhiteBear.Services.Catalog.Api.Data.Entities.Abstraction;

namespace WhiteBear.Services.Catalog.Api.Data.Entities
{
    public sealed class Image : BaseEntity
    {
        public string PreviewUrl { get; set; }
        public string ProductId { get; set; }
        public ProductItem ProductItem { get; set; }
    }
}
