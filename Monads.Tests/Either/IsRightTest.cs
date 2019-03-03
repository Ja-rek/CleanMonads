using NUnit.Framework;
using static Monads.EitherFactory;

namespace Monads.Tests.Either
{
    internal class IsRightTest : TestTemplate
    {
        [Test]
        public void IsRight_WhenRightEitherContainValue_RetrunsTrue()
        {
            Assert.True(rightStr_Any.IsRight());
            Assert.True(rightInt_Any.IsRight());
            Assert.True(rightInt_Default.IsRight());
        }

        [Test]
        public void IsRight_WhenLeftEitherNotContainValue_RetrunsFalse()
        {
            Assert.False(leftStr_Any.IsRight());
            Assert.False(leftInt_Any.IsRight());

            Assert.False(rightStr_Default.IsRight());
            Assert.False(Left("Error").IsRight());
        }

        [Test]
        public void IsRight_WhenRightEitherContainValueAnConditionIsMet_RetrunsTrue()
        {
            Assert.True(rightStr_Any.IsRight(x => x == str_Any));
            Assert.True(rightInt_10.IsRight(x => x < 20));
            Assert.True(rightInt_Default.IsRight(x => x == 0));
        }

        [Test]
        public void IsRight_WhenRightEitherContainNoValueAnConditionIsMet_RetrunsTrue()
        {
            Assert.False(rightStr_Any.IsRight(x => x == "wrong string"));
            Assert.False(rightInt_10.IsRight(x => x < 5));
            Assert.False(rightInt_Default.IsRight(x => x != 0));
        }
    }
}
