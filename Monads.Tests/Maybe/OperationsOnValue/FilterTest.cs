using System;
using NUnit.Framework;

namespace Monads.Tests.Maybe.OperationsOnValue
{
    internal class FilterTest : TestTemplate
    {
        [Test]
        public void Filter_WhenConditionIsMet_ReturnsMaybeByCondtion()
        {
            var actual = maybeInt_10.Filter(x => x == 10);

            Assert.AreEqual(maybeInt_10, actual);
        }

        [Test]
        public void Filter_WhenConditionIsNotMet_ReturnsCorrectValue()
        {
            var actual = maybeInt_10.Filter(x => x == 20);

            Assert.AreNotEqual(maybeInt_10, actual);
        }

        [Test]
        public void Filter_WhenFieldHasNothing_DoNotExecuteCondition()
        {
            str_Nothing.Filter(x => throw new Exception());
        }

        [Test]
        public void Filter_WhenFieldHasNothing_ReturnsMaybeWitNothing()
        {
            var actual = int_Nothing.Filter(x => x == 10);

            Assert.AreNotEqual(maybeInt_10, actual);
        }
    }
}
