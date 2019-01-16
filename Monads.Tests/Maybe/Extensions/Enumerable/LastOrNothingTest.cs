using NUnit.Framework;
using Monads.Maybe.Enumerable;
using Monads.Maybe;
using static Monads.Maybe.MaybeFactory;
using System;

namespace Monads.Tests.Maybe.Extensions.Enumerable
{
    internal class LastOrNothingTest : TestTemplate
    {
        [Test]
        public void LastOrNothing_WhenConditionIsMet_RetrunsJustTwo()
        {
            var lastOrNothing = listOf_1_2_3_4.LastOrNothing(x => x < 3);
            var expectedJust2 = Just(2);

            Assert.AreEqual(expectedJust2, lastOrNothing);
        }

        [Test]
        public void LastOrNothing_WhenConditionIsNotMet_RetrunsNothing()
        {
            var lastOrNothing = listOf_1_2_3_4.LastOrNothing(x => x > 10);
            Maybe<int> expectedNothing = Nothing;

            Assert.AreEqual(expectedNothing, lastOrNothing);
        }

        [Test]
        public void LastOrNothing_WhenListIsNull_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => listIsNull.LastOrNothing());
        }

        [Test]
        public void LastOrNothing_WhenListIsEmpty_RetrunsNothing()
        {
            var lastOrNothing = emptyList.LastOrNothing();
            Maybe<int> expectedNothing = Nothing;

            Assert.AreEqual(expectedNothing, lastOrNothing);
        }

        [Test]
        public void LastOrNothing_WhenListHasSomeItems_RetrunsJustTwo()
        {
            var lastOrNothing = listOf_1_2.LastOrNothing();
            var expectedJustTwo = Just(2);

            Assert.AreEqual(expectedJustTwo, lastOrNothing);
        }
    }
}
