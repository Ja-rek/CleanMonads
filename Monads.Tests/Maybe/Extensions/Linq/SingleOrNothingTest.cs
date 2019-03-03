using NUnit.Framework;
using static Monads.MaybeFactory;
using System;
using Monads.Extensions.Linq;

namespace Monads.Tests.Maybe.Extensions.Enumerable
{
    internal class SingleOrNothingTest : TestTemplate
    {
        [Test]
        public void SingleOrNothing_WhenConditionIsMet_RetrunsJustOne()
        {
            var singleOrNothing = listOf_1_2_3_4.SingleOrNothing(x => x < 2);
            var expectedJustOne = Just(1);

            Assert.AreEqual(expectedJustOne, singleOrNothing);
        }

        [Test]
        public void SingleOrNothing_WhenConditionIsNotMet_RetrunsNothing()
        {
            var singleOrNothing = listOf_1_2_3_4.SingleOrNothing(x => x > 10);
            Maybe<int> expectedNothing = Nothing;

            Assert.AreEqual(expectedNothing, singleOrNothing);
        }

        [Test]
        public void SingleOrNothing_WhenListIsNull_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => listOfMaybesThatIsNull.SingleOrNothing());
        }

        [Test]
        public void SingleOrNothing_WhenListIsEmpty_RetrunsNothing()
        {
            var singleOrNothing = emptyList.SingleOrNothing();
            Maybe<int> expectedNothing = Nothing;

            Assert.AreEqual(expectedNothing, singleOrNothing);
        }

        [Test]
        public void SingleOrNothing_WhenCollectionHasOneItem_RetrunsJustOne()
        {
            var singleOrNothing = listOf_1.SingleOrNothing();
            var expectedJustOne = Just(1);

            Assert.AreEqual(expectedJustOne, singleOrNothing);
        }
    }
}
