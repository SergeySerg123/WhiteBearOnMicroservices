using System;
using System.Net;
using WhiteBear.Services.Catalog.Api.Enums;
using WhiteBear.Services.Catalog.Api.Infrastructure.Exceptions;

namespace WhiteBear.Services.Catalog.Api.Extensions
{
    public static class ExceptionFilterExtensions
    {
        public static (HttpStatusCode statusCode, ErrorCode errorCode) ParseException(this Exception exception)
        {
            switch (exception)
            {
                case NotFoundEntityException _:
                    return (HttpStatusCode.NotFound, ErrorCode.NotFoundEntity);

                case NullPropsEntityException _:
                    return (HttpStatusCode.BadRequest, ErrorCode.NullPropsEntity);

                case CastEnumBeerTypeException _:
                    return (HttpStatusCode.InternalServerError, ErrorCode.CastEnumBeerType);

                default:
                    return (HttpStatusCode.InternalServerError, ErrorCode.General);
            }
        }
    }
}
