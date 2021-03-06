﻿using WhiteBear.Services.Catalog.Api.Enums;
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
                case 3:
                    return EnumBeerTypes.All;
                default:
                    throw new CastEnumBeerTypeException();
            }
        }
    }
}
