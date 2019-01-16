using NUnit.Framework;
using Monads.Either.Enumerable;
using Monads.Either;
using static Monads.Either.EitherFactory;
using System;

namespace Monads.Tests.Either.Extensions.Enumerable
{
    internal class ElementAtOrLeftTest : TestTemplate
    {
        [Test]
        public void ElementAtOrLeft_WhenItemExist_RetrunsItemByIndex()
        {
            var rightOrLeft = listOf_1_2.ElementAtOrLeft(0, () => str_Error);
            var expectedRight = EitherFrom(str_Error, 1);

            Assert.AreEqual(expectedRight, rightOrLeft);
        }

        [Test]
        public void ElementAtOrLeft_WhenItemNotExist_RetrunsItemByIndex()
        {
            var rightOrLeft = listOf_1_2.ElementAtOrLeft(5, () => str_Error);
            Either<string, int> expectedLeft = str_Error;

            Assert.AreEqual(expectedLeft, rightOrLeft);
        }

        [Test]
        public void ElementAtOrLeft_WhenListIsNull_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() 
                => listOfIntsThatIsNull.ElementAtOrLeft(1, () => str_Error));
        }

        [Test]
        public void ElementAtOrLeft_WhenListIsEmpty_RetrunsLeft()
        {
            var rightOrLeft = emtpyList.ElementAtOrLeft(1, () => str_Error);

            Either<string, int> expectedLeft = str_Error;

            Assert.AreEqual(expectedLeft, rightOrLeft);
        }
    }
}
