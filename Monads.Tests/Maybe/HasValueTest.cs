using NUnit.Framework;
using static Monads.MaybeFactory;

namespace Monads.Tests.Maybe
{
    internal class HasValueTest : TestTemplate
    {
        [Test]
        public void HasValue_WhenFieldHasValue_RetrunsTrue()
        {
            Assert.True(maybeStr_Any.HasValue());
            Assert.True(maybeInt_Any.HasValue());
            Assert.True(maybeInt_Default.HasValue());
        }

        [Test]
        public void HasValue_WhenFieldHasNoValue_RetrunsFalse()
        {
            Assert.False(str_Nothing.HasValue());
            Assert.False(int_Nothing.HasValue());

            Assert.False(maybeStr_Default.HasValue());
            Assert.False(Nothing.HasValue());
        }

        [Test]
        public void HasValue_WhenFieldHasValueAnConditionIsMet_RetrunsTrue()
        {
            Assert.True(maybeStr_Any.HasValue(x => x == str_Any));
            Assert.True(maybeInt_10.HasValue(x => x < 20));
            Assert.True(maybeInt_Default.HasValue(x => x == 0));
        }

        [Test]
        public void HasValue_WhenFieldHasValueAnConditionIsNotMet_RetrunsTrue()
        {
            Assert.False(maybeStr_Any.HasValue(x => x == "wrong string"));
            Assert.False(maybeInt_10.HasValue(x => x < 5));
            Assert.False(maybeInt_Default.HasValue(x => x != 0));
        }
    }
}
