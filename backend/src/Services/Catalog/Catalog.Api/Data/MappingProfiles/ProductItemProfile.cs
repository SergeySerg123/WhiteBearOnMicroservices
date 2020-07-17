using AutoMapper;
using WhiteBear.Services.Catalog.Api.Data.DTO.ProductItem;
using WhiteBear.Services.Catalog.Api.Data.Entities;
using static WhiteBear.Services.Catalog.Api.Extensions.Utils;

namespace WhiteBear.Services.Catalog.Api.Data.MappingProfiles
{
    public sealed class ProductItemProfile : Profile
    {
        public ProductItemProfile()
        {
            CreateMap<ProductItemDTO, ProductItem>()
                .ForMember(dest => dest.PreviewImg, s => s.MapFrom(sr => string.IsNullOrEmpty(sr.PreviewImg) ? null : new Image { URL = sr.PreviewImg }));

            CreateMap<ProductItem, ProductItemDTO>()
                .ForMember(dest => dest.PreviewImg, src => src.MapFrom(x => x.PreviewImg != null ? x.PreviewImg.URL : string.Empty));
                 
            
            CreateMap<NewProductItemDTO, ProductItem>()
                .ForMember(dest => dest.PreviewImg, s => s.MapFrom(sr => string.IsNullOrEmpty(sr.PreviewImg) ? null : new Image { URL = sr.PreviewImg }))
                .ForMember(dest => dest.BeerType, src => src.MapFrom(x => GetEnumBeerTypeFromIntType(x.BeerType))); 
        }
    }
}
