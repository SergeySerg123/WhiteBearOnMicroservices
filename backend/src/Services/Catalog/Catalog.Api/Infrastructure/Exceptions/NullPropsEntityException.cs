using System;

namespace WhiteBear.Services.Catalog.Api.Infrastructure.Exceptions
{
    public sealed class NullPropsEntityException : Exception
    {
        public NullPropsEntityException(string message) : base(message)
        {
        }
    }
}
