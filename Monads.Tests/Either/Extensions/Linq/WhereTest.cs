using NUnit.Framework;
using Monads.Either.Linq;

namespace Monads.Tests.Either.Extensions.Linq
{
    internal class WhereTest : TestTemplate
    {
        [Test]
        public void Where_WhenEitherContainRightValueAndConditionIsMet_RetrunsRightEither()
        {
            var actual = rightInt_10.Where(x => x == 10, str_Error);

            Assert.AreEqual(rightInt_10, actual);
        }

        [Test]
        public void Where_WhenEitherContainRightValueAndConditionIsNotMet_RetrunsLeftEither()
        {
            var actual = rightInt_10.Where(x => x != 10, str_Any);

            Assert.AreEqual(leftStr_Any, actual);
        }

        [Test]
        public void Where_WhenEitherContainLeftValueAndConditionCanNotBeMet_RetrunsLeftEither()
        {
            var actual = leftStr_Error.Where(x => x == 10, str_Error);

            Assert.AreEqual(leftStr_Error, actual);
        }
    }
}
