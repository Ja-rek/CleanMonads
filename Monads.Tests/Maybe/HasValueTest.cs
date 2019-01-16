using NUnit.Framework;
using static Monads.Maybe.MaybeFactory;

namespace Monads.Tests.Maybe
{
    internal class HasValueTest : TestTemplate
    {
        [Test]
        public void HasValue_WhenMaybeHasValue_RetrunsTrue()
        {
            Assert.True(maybeStr_Any.HasValue());
            Assert.True(maybeInt_Any.HasValue());
            Assert.True(maybeInt_Default.HasValue());
        }

        [Test]
        public void HasValue_WhenMaybeHasNoValue_RetrunsFalse()
        {
            Assert.False(str_Nothing.HasValue());
            Assert.False(int_Nothing.HasValue());

            Assert.False(maybeStr_Default.HasValue());
            Assert.False(Nothing.HasValue());
        }

        [Test]
        public void HasValue_WhenMaybeHasValueAnConditionIsMet_RetrunsTrue()
        {
            Assert.True(maybeStr_Any.HasValue(x => x == str_Any));
            Assert.True(maybeInt_10.HasValue(x => x < 20));
            Assert.True(maybeInt_Default.HasValue(x => x == 0));
        }

        [Test]
        public void HasValue_WhenMaybeHasValueAnConditionIsNotMet_RetrunsTrue()
        {
            Assert.False(maybeStr_Any.HasValue(x => x == "wrong string"));
            Assert.False(maybeInt_10.HasValue(x => x < 5));
            Assert.False(maybeInt_Default.HasValue(x => x != 0));
        }
    }
}
