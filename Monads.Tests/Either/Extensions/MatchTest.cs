using NUnit.Framework;
using Monads.Either;
using System;
using static Monads.Either.EitherFactory;

namespace Monads.Tests.Either.Extensions
{
    internal class MatchTest : TestTemplate
    {
        [Test]
        public void MatchExtensionMethod_WhenRightEitherContainValue_RetrunsRightValue()
        {
            var mached = rightStr_10.Match(
                left => left,
                right => right);

            Assert.AreEqual(str_10, mached);
        }

        [Test]
        public void MatchExtensionMethod_WhenLeftEitherContainValue_ReturnsLeftValue()
        {
            var mached = leftInt_10.Match(
                left => left,
                right => right);

            Assert.AreEqual(int_10, mached);
        }

        [Test]
        public void MatchExtensionMethod_WhenLeftArgumentIsNull_ThrowException()
        {
            Either<string, string> either = Left("Error.");

            Assert.Throws<ArgumentNullException>(() => 
                either.Match(
                    left => null,
                    right => right));
        }

        [Test]
        public void MatchExtensionMethod_WhenRightArgumentIsNull_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => 
                rightStr_10.Match(
                    left => left,
                    right => null));
        }

        [Test]
        [TestCase(null)]
        public void MatchExtensionMethod_WhenSourceIsNull_ThrowException(Either<string, string> source)
        {
            Assert.Throws<InvalidOperationException>(() => 
                source.Match(
                    left => left,
                    right => right));
        }
    }
}
