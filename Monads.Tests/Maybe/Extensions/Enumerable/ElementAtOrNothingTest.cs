using NUnit.Framework;
using Monads.Maybe.Enumerable;
using Monads.Maybe;
using static Monads.Maybe.MaybeFactory;
using System;

namespace Monads.Tests.Maybe.Extensions.Enumerable
{
    internal class ElementAtOrNothingTest : TestTemplate
    {

        [Test]
        public void ElementAtOrNothing_WhenItemExist_RetrunsItemByIndex()
        {
            var justTwoOrNothing = listOf_1_2.ElementAtOrNothing(1);
            var expectedJustTwo = Just(2);

            Assert.AreEqual(expectedJustTwo, justTwoOrNothing);
        }

        [Test]
        public void ElementAtOrNothing_WhenItemNotExist_RetrunsNothing()
        {
            var justOrNothing = listOf_1_2.ElementAtOrNothing(5);
            Maybe<int> expectedNothing = Nothing;

            Assert.AreEqual(expectedNothing, justOrNothing);
        }

        [Test]
        public void ElementAtOrNothing_WhenListIsNull_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => listOfMaybesThatIsNull.ElementAtOrNothing(1));
        }

        [Test]
        public void ElementAtOrNothing_WhenListIsEmpty_RetrunsNothing()
        {
            var elementAtOrNothing = emptyList.ElementAtOrNothing(1);
            Maybe<int> expectedNothing = Nothing;

            Assert.AreEqual(expectedNothing, elementAtOrNothing);
        }
    }
}
