using NUnit.Framework;
using static Monads.MaybeFactory;

namespace Monads.Tests.Maybe
{
    internal class CompareToTest : TestTemplate
    {
        [Test]
        public void CompareTo_WhenMaybeHasTheSameValues_ReturnsZero()
        {
            Assert.True(maybeStr_Any.CompareTo(str_Any) == 0);
            Assert.True(maybeStr_Any.CompareTo(maybeStr_Any) == 0);
            Assert.True(str_Nothing.CompareTo(str_Nothing) == 0);
            Assert.True(str_Nothing.CompareTo(Nothing) == 0);
            Assert.True(maybeStr_Default.CompareTo(maybeStr_Default) == 0);

            Assert.True(maybeInt_Any.CompareTo(int_Any) == 0);
            Assert.True(maybeInt_Any.CompareTo(maybeInt_Any) == 0);
            Assert.True(int_Nothing.CompareTo(int_Nothing) == 0);
            Assert.True(int_Nothing.CompareTo(Nothing) == 0);
            Assert.True(maybeInt_Default.CompareTo(maybeInt_Default) == 0);
        }

        [Test]
        public void CompareTo_WhenLeftMaybeIsGreater_ReturnsOne()
        {
            Assert.True(maybeInt_20.CompareTo(int_10) ==  1);
            Assert.True(maybeInt_20.CompareTo(maybeInt_10) ==  1);

            Assert.True(maybeStr_20.CompareTo(str_10) ==  1);
            Assert.True(maybeStr_20.CompareTo(maybeStr_10) ==  1);
        }

        [Test]
        public void CompareTo_WhenLeftMaybeIsLesser_ReturnsMinusOne()
        {
            Assert.True(maybeInt_10.CompareTo(int_20) ==  -1);
            Assert.True(maybeInt_10.CompareTo(maybeInt_20) ==  -1);

            Assert.True(maybeStr_10.CompareTo(str_20) ==  -1);
            Assert.True(maybeStr_10.CompareTo(maybeStr_20) ==  -1);
        }

        [Test]
        public void CompareTo_WhenLeftMaybeHasNothing_ReturnsMinusOne()
        {
            Assert.True(int_Nothing.CompareTo(maybeInt_Any) ==  -1);
            Assert.True(int_Nothing.CompareTo(int_Any) ==  -1);

            Assert.True(str_Nothing.CompareTo(maybeStr_Any) ==  -1);
            Assert.True(str_Nothing.CompareTo(str_Any) ==  -1);
        }

        [Test]
        public void CompareTo_WhenRightMaybeHasNothing_ReturnsOne()
        {
            Assert.True(maybeInt_Any.CompareTo(int_Nothing) ==  1);
            Assert.True(maybeStr_Any.CompareTo(str_Nothing) ==  1);
            Assert.True(maybeStr_Any.CompareTo(Nothing) ==  1);
        }

        [Test]
        public void CompareTo_WhenLeftMaybeIsDefault_ReturnsMinusOne()
        {
            Assert.True(maybeInt_Default.CompareTo(maybeInt_Any) ==  -1);
            Assert.True(maybeInt_Default.CompareTo(int_Any) ==  -1);

            Assert.True(maybeStr_Default.CompareTo(maybeStr_Any) ==  -1);
            Assert.True(maybeStr_Default.CompareTo(str_Any) ==  -1);
        }

        [Test]
        public void CompareTo_WhenRightMaybeIsDefault_ReturnsOne()
        {
            Assert.True(maybeInt_Any.CompareTo(maybeInt_Default) ==  1);
            Assert.True(maybeStr_Any.CompareTo(maybeStr_Default) ==  1);
        }
    }
}
