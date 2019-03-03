using NUnit.Framework;
using System;
using static Monads.EitherFactory;

namespace Monads.Tests.Either.RetrievingValue
{
    internal class AdjustTest : TestTemplate
    {
        [Test]
        public void AdjustExtensionMethod_WhenRightEitherContainValue_RetrunsRightValue()
        {
            var mached = rightStr_10.Adjust(
                left => left,
                right => right);

            Assert.AreEqual(str_10, mached);
        }

        [Test]
        public void AdjustExtensionMethod_WhenLeftEitherContainValue_ReturnsLeftValue()
        {
            var mached = leftInt_10.Adjust(
                left => left,
                right => right);

            Assert.AreEqual(int_10, mached);
        }

        [Test]
        public void AdjustExtensionMethod_WhenLeftArgumentIsNull_ThrowException()
        {
            Either<string, string> either = Left("Error.");

            Assert.Throws<ArgumentNullException>(() => 
                either.Adjust(
                    left => null,
                    right => right));
        }

        [Test]
        public void AdjustExtensionMethod_WhenRightArgumentIsNull_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => 
                rightStr_10.Adjust(
                    left => left,
                    right => null));
        }
    }
}
