using NUnit.Framework;
using Monads.Maybe.Enumerable;
using Monads.Maybe;
using static Monads.Maybe.MaybeFactory;
using System;

namespace Monads.Tests.Maybe.Extensions.Enumerable
{
    internal class FirstOrNothingTest : TestTemplate
    {

        [Test]
        public void FirstOrNothing_WhenConditionIsMet_RetrunsJustOne()
        {
            var array = listOf_1_2_3_4;

            var firstOrNothing = array.FirstOrNothing(x => x < 3);
            var expectedJustTwo = Just(1);

            Assert.AreEqual(expectedJustTwo, firstOrNothing);
        }

        [Test]
        public void FirstOrNothing_WhenConditionIsNotMet_RetrunsJustOne()
        {
            var array = listOf_1_2_3_4;

            var firstOrNothing = array.FirstOrNothing(x => x > 10);
            Maybe<int> expectedNothing = Nothing;

            Assert.AreEqual(expectedNothing, firstOrNothing);
        }

        [Test]
        public void FirstOrNothing_WhenListIsNull_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => listOfMaybesThatIsNull.FirstOrNothing());
        }

        [Test]
        public void FirstOrNothing_WhenListIsEmpty_RetrunsNothing()
        {
            var firstOrNothing = emptyList.FirstOrNothing();
            Maybe<int> expectedNothing = Nothing;

            Assert.AreEqual(expectedNothing, firstOrNothing);
        }

        [Test]
        public void FirstOrNothing_WhenCollectionHasSomeItems_RetrunsNothing()
        {
            var firstOrNothing = listOf_1_2.FirstOrNothing();
            var expectedJustOne = Just(1);

            Assert.AreEqual(expectedJustOne, firstOrNothing);
        }

    }
}
