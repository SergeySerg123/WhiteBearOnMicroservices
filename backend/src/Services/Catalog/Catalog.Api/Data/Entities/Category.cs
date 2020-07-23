﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WhiteBear.Services.Catalog.Api.Data.Entities.Abstraction;

namespace WhiteBear.Services.Catalog.Api.Data.Entities
{
    public sealed class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string ProductItemId { get; set; }
        public ICollection<ProductItem> ProductItems { get; set; } 
        public string BrandId { get; set; }
        public ICollection<Brand> Brands { get; set; }
    }
}
