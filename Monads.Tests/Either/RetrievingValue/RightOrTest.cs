using NUnit.Framework;
using static Monads.EitherFactory;
using System;

namespace Monads.Tests.Either.RetrievingValue
{
    internal class RightOrTest : TestTemplate
    {
        [Test]
        public void RightOr_WhenRightEitherContainValue_RetrunsRightValue()
        {
            var actual = rightStr_10.RightOr(left => left);

            Assert.AreEqual(str_10, actual);
        }

        [Test]
        public void RightOr_WhenLeftEitherContainValue_RetrunsLeftValue()
        {
            var actual = leftInt_10.RightOr(left => left +10);

            Assert.AreEqual(int_20, actual);
        }

        [Test]
        public void RightOr_WhenArgumentIsNull_ThrowException()
        {
            Either<string, string> either = Left("Error.");

            Assert.Throws<ArgumentNullException>(() => either.RightOr(left => null));
        }
    }
}
