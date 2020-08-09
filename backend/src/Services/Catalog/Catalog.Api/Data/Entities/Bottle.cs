using WhiteBear.Services.Catalog.Api.Data.Entities.Abstraction;

namespace WhiteBear.Services.Catalog.Api.Data.Entities
{
    public class Bottle : BaseEntity
    {
        public double Price { get; set; }
        public double Capacity { get; set; }
    }
}
