using System;

namespace WhiteBear.Services.Catalog.Api.Infrastructure.Exceptions
{
    public sealed class NotFoundEntityException : Exception
    {
        public NotFoundEntityException(string message) : base(message)
        {
        }
    }
}
