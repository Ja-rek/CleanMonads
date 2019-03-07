using NUnit.Framework;
using static Monads.EitherFactory;
using System;

namespace Monads.Tests.Either.RetrievingValue
{
    internal class LeftOrTest : TestTemplate
    {
        [Test]
        public void LeftOr_WhenMonadHasTheSamesTypeAndRightSideContainsValue_RetrunsAlternativeLeftValue()
        {
            var either = Right<int, int>(10);

            var actual = either.LeftOr(right => right + 5);

            Assert.AreEqual(15, actual);
        }

        [Test]
        public void LeftOr_WhenRightSideContainValueInOtherType_RetrunsAlternativeLeftValue()
        {
            var either = Right<int, string>("any");

            var actual = either.LeftOr(10);

            Assert.AreEqual(10, actual);
        }

        [Test]
        public void LeftOr_WhenMonadHasTheSameTypesAndLeftSideContainsValue_RetrunsLeftValue()
        {
            var either = Left<int, int>(10);

            var actual = either.LeftOr(right => right + 5);

            Assert.AreEqual(10, actual);
        }

        [Test]
        public void LeftOr_WhenLeftSideContainValue_RetrunsLeftValue()
        {
            var either = Left(5);

            var actual = either.LeftOr(10);

            Assert.AreEqual(5, actual);
        }

        [Test]
        public void LeftOr_WhenArgumentIsNull_ThrowException()
        {
            var either = Right<string, string>("test");

            Assert.Throws<ArgumentNullException>(() => either.LeftOr(left => null));
        }
    }
}
