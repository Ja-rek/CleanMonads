using NUnit.Framework;
using Monads.Either.Enumerable;
using Monads.Either;
using static Monads.Either.EitherFactory;
using System;

namespace Monads.Tests.Either.Extensions.Enumerable
{
    internal class LastOrLeftTest : TestTemplate
    {
        [Test]
        public void LastOrLeft_WhenConditionIsMet_RetrunsRight()
        {
            var lastOrLeft = listOf_1_2.LastOrLeft(x => x < 2, () => str_Error);
            var expectedRight = EitherFrom(str_Error, 1);

            Assert.AreEqual(expectedRight, lastOrLeft);
        }

        [Test]
        public void LastOrLeft_WhenConditionIsNotMet_RetrunsLeft()
        {
            var lastOrLeft = listOf_1_2.LastOrLeft(x => x > 5, () => str_Error);
            Either<string, int> expectedLeft = str_Error;

            Assert.AreEqual(expectedLeft, lastOrLeft);
        }

        [Test]
        public void LastOrLeft_WhenListIsNull_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() 
                => listOfIntsThatIsNull.LastOrLeft(() => str_Error));
        }

        [Test]
        public void LastOrLeft_WhenListIsEmpty_RetrunsLeft()
        {
            var lastOrLeft = emtpyList.LastOrLeft(() => str_Error);
            Either<string, int> expectedLeft = str_Error;

            Assert.AreEqual(expectedLeft, lastOrLeft);
        }

        [Test]
        public void LastOrLeft_WhenListHasSomeItems_RetrunsRight()
        {
            var lastOrLeft = listOf_1_2.LastOrLeft(() => str_Error);
            var expectedRight = EitherFrom(str_Error, 2);

            Assert.AreEqual(expectedRight, lastOrLeft);
        }
    }
}
