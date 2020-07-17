namespace WhiteBear.Services.Catalog.Api.Data.DTO.ProductItem
{
    public sealed class NewProductItemDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Discount { get; set; } = 0.0;
        public decimal Price { get; set; }
        public int BeerType { get; set; }
        public double Density { get; set; }
        public string PreviewImgUrl { get; set; }
        public string CategoryId { get; set; }
        public string BrandId { get; set; }
    }
}
