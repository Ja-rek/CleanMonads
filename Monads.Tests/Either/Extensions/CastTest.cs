using NUnit.Framework;
using Monads.Either;

namespace Monads.Tests.Either.Extensions
{
    internal class CastTest : TestTemplate
    {
        [Test]
        public void ToRightIf_WhenConditionIsMet_ReturnRightEither()
        {
            var actual = int_10.ToRightIf(x => x == 10, str_Error);

            Assert.AreEqual(rightInt_10, actual);
        }

        [Test]
        public void ToRightIf_WhenConditionIsNotMet_ReturnLeftEither()
        {
            var actual = int_10.ToRightIf(x => x != 10, str_Error);

            Assert.AreEqual(leftStr_Error, actual);
        }

        [Test]
        public void ToLeftIf_WhenConditionIsMet_ReturnLeftEither()
        {
            var actual = int_10.ToLeftIf(x => x == 10, str_Error);

            Assert.AreEqual(leftStr_Error, actual);
        }

        [Test]
        public void ToLeftIf_WhenConditionIsNotMet_ReturnRightEither()
        {
            var actual = int_10.ToLeftIf(x => x != 10, str_Error);

            Assert.AreEqual(rightInt_10, actual);
        }
    }
}
