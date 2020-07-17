using WhiteBear.Services.Catalog.Api.Data.Entities;
using WhiteBear.Services.Catalog.Api.Infrastructure.Exceptions;

namespace WhiteBear.Services.Catalog.Api.Extensions
{
    public static class Utils
    {
        public static EnumBeerTypes GetEnumBeerTypeFromIntType(int type)
        {
            switch (type)
            {
                case 0:
                    return EnumBeerTypes.White;
                case 1:
                    return EnumBeerTypes.Dark;
                case 2:
                    return EnumBeerTypes.Unfiltered;
                default:
                    throw new CastEnumBeerTypeException();
            }
        }
    }
}
