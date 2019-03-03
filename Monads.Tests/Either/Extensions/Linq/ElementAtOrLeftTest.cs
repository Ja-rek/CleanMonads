using NUnit.Framework;
using static Monads.EitherFactory;
using System;
using Monads.Extensions.Linq;

namespace Monads.Tests.Either.Extensions.Linq
{
    internal class ElementAtOrLeftTest : TestTemplate
    {
        [Test]
        public void ElementAtOrLeft_WhenItemExist_RetrunsItemByIndex()
        {
            var rightOrLeft = listOf_1_2.ElementAtOrLeft(0, () => str_Error);
            var expectedRight = EitherOf(str_Error, 1);

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
