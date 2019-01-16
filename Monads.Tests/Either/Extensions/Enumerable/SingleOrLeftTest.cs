using NUnit.Framework;
using Monads.Either.Enumerable;
using Monads.Either;
using static Monads.Either.EitherFactory;
using System;

namespace Monads.Tests.Either.Extensions.Enumerable
{
    internal class SingleOrLeftTest : TestTemplate
    {
        [Test]
        public void SingleOrLeft_WhenConditionIsMet_RetrunsRight()
        {
            var singleOrLeft = listOf_1_2.SingleOrLeft(x => x < 2, () => str_Error);
            var expectedRightOne = EitherFrom(str_Error, 1);

            Assert.AreEqual(expectedRightOne, singleOrLeft);
        }

        [Test]
        public void SingleOrLeft_WhenConditionIsNotMet_RetrunsLeft()
        {
            var singleOrLeft = listOf_1_2.SingleOrLeft(x => x > 5, () => str_Error);
            Either<string, int> expectedLeft = str_Error;

            Assert.AreEqual(expectedLeft, singleOrLeft);
        }

        [Test]
        public void SingleOrLeft_WhenListIsNull_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(()
                => listOfIntsThatIsNull.SingleOrLeft(() => str_Error));
        }

        [Test]
        public void SingleOrLeft_WhenListIsEmpty_RetrunsLeft()
        {
            var singleOrLeft = emtpyList.SingleOrLeft(() => str_Error);
            Either<string, int> expectedLeft = str_Error;

            Assert.AreEqual(expectedLeft, singleOrLeft);
        }

        [Test]
        public void SingleOrLeft_WhenCollectionHasOneItem_RetrunsRight()
        {
            var singleOrLeft = listOf_1.SingleOrLeft(() => str_Error);
            var expectedRight = EitherFrom(str_Error, 1);

            Assert.AreEqual(expectedRight, singleOrLeft);
        }
    }
}
