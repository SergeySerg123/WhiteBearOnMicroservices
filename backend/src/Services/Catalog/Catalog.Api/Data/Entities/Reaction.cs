using System.ComponentModel.DataAnnotations;
using WhiteBear.Services.Catalog.Api.Data.Entities.Abstraction;

namespace WhiteBear.Services.Catalog.Api.Data.Entities
{
    public sealed class Reaction : BaseEntity
    {
        public int Value { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
