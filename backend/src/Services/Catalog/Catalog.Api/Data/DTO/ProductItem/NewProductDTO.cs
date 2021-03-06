﻿namespace WhiteBear.Services.Catalog.Api.Data.DTO.ProductItem
{
    public sealed class NewProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Discount { get; set; } = 0.0;
        public decimal Price { get; set; }
        public int BeerType { get; set; }
        public double Density { get; set; }
        public string PreviewImg { get; set; }
        public string CategoryId { get; set; }
        public string BrandId { get; set; }
    }
}
