using NUnit.Framework;

namespace Monads.Tests.Maybe.ValueOperations
{
    internal class FilterTest : TestTemplate
    {
        [Test]
        public void Filter_WhenMaybeHasValue_ReturnsMaybeByCondtion()
        {
            var actual = maybeInt_10.Filter(x => x == 10);

            Assert.AreEqual(maybeInt_10, actual);
        }

        [Test]
        public void Filter_WhenMaybeHasNothing_ReturnsMaybeWitNothing()
        {
            var actual = int_Nothing.Filter(x => x == 10);

            Assert.AreNotEqual(maybeInt_10, actual);
        }
    }
}
