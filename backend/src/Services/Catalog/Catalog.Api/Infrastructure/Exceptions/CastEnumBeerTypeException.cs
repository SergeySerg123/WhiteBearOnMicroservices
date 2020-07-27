using System;

namespace WhiteBear.Services.Catalog.Api.Infrastructure.Exceptions
{
    public sealed class CastEnumBeerTypeException : Exception
    {
        public CastEnumBeerTypeException() : base("Can't cast type to EnumBeerTypes") { }
    }
}
