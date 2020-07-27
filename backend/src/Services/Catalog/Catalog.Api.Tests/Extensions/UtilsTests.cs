using WhiteBear.Services.Catalog.Api.Enums;
using static WhiteBear.Services.Catalog.Api.Extensions.Utils;
using Xunit;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Infrastructure.Exceptions;

namespace Catalog.Api.Tests.Extensions
{
    public class UtilsTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetEnumBeerTypeFromIntType_Then_No_Exception(int value)
        {
            var type = GetEnumBeerTypeFromIntType(value);
            Assert.IsType<EnumBeerTypes>(type);
        }

        [Theory]
        [InlineData(4)]
        public void GetEnumBeerTypeFromIntType_Then_Throw_Exception(int value)
        {
            Assert.Throws<CastEnumBeerTypeException>(() => GetEnumBeerTypeFromIntType(value));
        }
    }
}
