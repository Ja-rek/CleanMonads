using NUnit.Framework;
using Monads.Extensions.Unsafe;

namespace Monads.Tests.Either.Extensions
{
    internal class CastTest : TestTemplate
    {
        [Test]
        public void ToRightIf_WhenConditionIsMet_ReturnRightEither()
        {
            var actual = int_10.ToRightIf(x => x == 10, () => str_Error);

            Assert.AreEqual(rightInt_10, actual);
        }

        [Test]
        public void ToRightIf_WhenConditionIsNotMet_ReturnLeftEither()
        {
            var actual = int_10.ToRightIf(x => x != 10,() => str_Error);

            Assert.AreEqual(leftStr_Error, actual);
        }

        [Test]
        public void ToLeftIf_WhenConditionIsMet_ReturnLeftEither()
        {
            var actual = int_10.ToLeftIf(x => x == 10,() => str_Error);

            Assert.AreEqual(leftStr_Error, actual);
        }

        [Test]
        public void ToLeftIf_WhenConditionIsNotMet_ReturnRightEither()
        {
            var actual = int_10.ToLeftIf(x => x != 10,() => str_Error);

            Assert.AreEqual(rightInt_10, actual);
        }

        [Test]
        public void ToEither_WhenNullableRightHasValue_ReturnRightEither()
        {
            var actual = nullableInt_10.ToEither(() => str_Error);

            Assert.AreEqual(rightInt_10, actual);
        }

        [Test]
        public void ToEither_WhenNullableSourceIsNull_ReturnLeftEither()
        {
            var actual = nullableInt_Null.ToEither(() => str_Error);

            Assert.AreEqual(leftStr_Error, actual);
        }

        [Test]
        public void ToEither_WhenSourceHasValue_ReturnRightEither()
        {
            var actual = nullableInt_10.ToEither(() => str_Error);

            Assert.AreEqual(rightInt_10, actual);
        }

        [Test]
        public void ToEither_WhenSurceIsNull_ReturnLeftEither()
        {
            var actual = str_Default.ToEither(() => str_Error);

            Assert.AreEqual(str_Error, actual.Left());
        }

        [Test]
        public void ToEither_WhenSurceHasValue_ReturnRightEither()
        {
            var actual = int_10.ToEither(() => str_Error);

            Assert.AreEqual(rightInt_10, actual);
        }
    }
}
