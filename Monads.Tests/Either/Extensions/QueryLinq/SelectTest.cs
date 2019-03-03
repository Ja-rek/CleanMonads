using NUnit.Framework;
using Monads.Extensions.Linq;

namespace Monads.Tests.Either.Extensions.QueryLinq
{
    internal class SelectTest : TestTemplate
    {
        [Test]
        public void QuerySelect_WhenEitherContainValue_RetrunsSelectedValue()
        {
            var actual = from just in rightInt_10
                         select just + 10;

            Assert.AreEqual(rightInt_20, actual);
        }

        [Test]
        public void QuerySelect_WhenEitherContainNoValue_ReturnsLeftEither()
        {
            var actual = from just in leftStr_Error
                         select just + 10;

            Assert.AreEqual(leftStr_Error, actual);
        }
    }
}
