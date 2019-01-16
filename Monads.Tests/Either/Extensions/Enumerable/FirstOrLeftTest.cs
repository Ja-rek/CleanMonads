using NUnit.Framework;
using Monads.Either.Enumerable;
using Monads.Either;
using static Monads.Either.EitherFactory;
using System;

namespace Monads.Tests.Either.Extensions.Enumerable
{
    internal class FirstOrLeftTest : TestTemplate
    {
        [Test]
        public void FirstOrLeft_WhenItemExistAndConditionIsMet_RetrunsRight()
        {
            var firstOrLeft = listOf_1_2.FirstOrLeft(x => x > 1, () => str_Error);
            var expectedRight = EitherFrom(str_Error, 2);

            Assert.AreEqual(expectedRight, firstOrLeft);
        }

        [Test]
        public void FirstOrLeft_WhenItemExistAndConditionIsNotMet_RetrunsLeft()
        {
            var firstOrLeft = listOf_1_2.FirstOrLeft(x => x == 69, () => str_Error);
            Either<string, int> expectedLeft = Left(str_Error);

            Assert.AreEqual(expectedLeft, firstOrLeft);
        }

        [Test]
        public void FirstOrLeft_WhenListIsNull_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() 
                => listOfIntsThatIsNull.FirstOrLeft(() => str_Error));
        }

        [Test]
        public void FirstOrLeft_WhenListIsEmpty_RetrunsLeft()
        {
            var firstOrLeft = emtpyList.FirstOrLeft(() => str_Error);
            Either<string, int> expectedLeft = Left(str_Error);

            Assert.AreEqual(expectedLeft, firstOrLeft);
        }

        [Test]
        public void FirstOrLeft_WhenCollectionHasItems_RetrunsRight()
        {
            var firstOrLeft = listOf_1_2.FirstOrLeft(() => str_Error);
            var expectedRight =  EitherFrom(str_Error, 1);

            Assert.AreEqual(expectedRight, firstOrLeft);
        }

    }
}
