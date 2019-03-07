using NUnit.Framework;

namespace Monads.Tests.Maybe.OperationsOnValue
{
    internal class FilterTest : TestTemplate
    {
        [Test]
        public void Filter_WhenFieldHasValue_ReturnsMaybeByCondtion()
        {
            var actual = maybeInt_10.Filter(x => x == 10);

            Assert.AreEqual(maybeInt_10, actual);
        }

        [Test]
        public void Filter_WhenFieldHasNothing_ReturnsMaybeWitNothing()
        {
            var actual = int_Nothing.Filter(x => x == 10);

            Assert.AreNotEqual(maybeInt_10, actual);
        }
    }
}
