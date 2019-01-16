using NUnit.Framework;
using Monads.Either;
using static Monads.Either.EitherFactory;
using System;

namespace Monads.Tests.Either.Extensions
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

        [Test]
        [TestCase(null)]
        public void RightOr_WhenSourceIsNull_ThrowException(Either<int, int> source)
        {
            Assert.Throws<InvalidOperationException>(() => source.RightOr(left => left));
        }
    }
}
