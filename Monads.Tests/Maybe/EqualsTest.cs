using NUnit.Framework;
using static Monads.MaybeFactory;

namespace Monads.Tests.Maybe
{
    internal class EqualsMethodsTest : TestTemplate
    {
        [Test]
        public void Equals_WhenBothValuesAreTheSame_RetrunsTrue()
        {
            Assert.True(maybeStr_Any.Equals(str_Any));//Implicit cast.
            Assert.True(maybeStr_Any.Equals(maybeStr_Any));
            Assert.True(str_Nothing.Equals(str_Nothing));
            Assert.True(str_Nothing.Equals(Nothing));
            Assert.True(Nothing.Equals(str_Nothing));
            Assert.True(maybeStr_Default.Equals(maybeStr_Default));

            Assert.True(maybeInt_Any.Equals(int_Any));
            Assert.True(maybeInt_Any.Equals(maybeInt_Any));
            Assert.True(int_Nothing.Equals(int_Nothing));
            Assert.True(int_Nothing.Equals(Nothing));
            Assert.True(Nothing.Equals(int_Nothing));
            Assert.True(maybeInt_Default.Equals(maybeInt_Default));
        }

        [Test]
        public void Equals_WhenLeftMaybeIsGreater_RetrunsFalse()
        {
            Assert.False(maybeInt_20.Equals(int_10));
            Assert.False(maybeInt_20.Equals(maybeInt_10));

            Assert.False(maybeStr_20.Equals(str_10));
            Assert.False(maybeStr_20.Equals(maybeStr_10));
        }

        [Test]
        public void Equals_WhenLeftMaybeIsLesser_RetrunsFalse()
        {
            Assert.False(maybeInt_10.Equals(int_20));
            Assert.False(maybeInt_10.Equals(maybeInt_20));

            Assert.False(maybeStr_10.Equals(str_20));
            Assert.False(maybeStr_10.Equals(maybeStr_20));
        }

        [Test]
        public void Equals_WhenLeftMaybeHasNothing_RetrunsFalse()
        {
            Assert.False(int_Nothing.Equals(maybeInt_Any));
            Assert.False(int_Nothing.Equals(int_Any));

            Assert.False(str_Nothing.Equals(maybeStr_Any));
            Assert.False(str_Nothing.Equals(str_Any));
        }

        [Test]
        public void Equals_WhenRightMaybeHasNothing_RetrunsFalse()
        {
            Assert.False(maybeInt_Any.Equals(int_Nothing));
            Assert.False(maybeStr_Any.Equals(str_Nothing));
            Assert.False(maybeStr_Any.Equals(Nothing));
        }

        [Test]
        public void Equals_WhenLeftMaybeIsDefault_RetrunsFalse()
        {
            Assert.False(maybeInt_Default.Equals(maybeInt_Any));
            Assert.False(maybeInt_Default.Equals(int_Any));

            Assert.False(maybeStr_Default.Equals(maybeStr_Any));
            Assert.False(maybeStr_Default.Equals(str_Any));
        }

        [Test]
        public void Equals_WhenRightMaybeIsDefault_RetrunsFalse()
        {
            Assert.False(maybeInt_Any.Equals(maybeInt_Default));
            Assert.False(maybeStr_Any.Equals(maybeStr_Default));
        }
    }
}
