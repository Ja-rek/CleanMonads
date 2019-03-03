using NUnit.Framework;
using static Monads.EitherFactory;

namespace Monads.Tests.Either
{
    internal class IsLeftTest : TestTemplate
    {
        [Test]
        public void IsLeft_WhenLeftEitherContainValue_RetrunsTrue()
        {
            Assert.True(leftStr_Any.IsLeft());
            Assert.True(leftInt_Any.IsLeft());
            Assert.True(leftInt_Default.IsLeft());
        }

        [Test]
        public void IsLeft_WhenRightEitherContainValue_RetrunsFalse()
        {
            Assert.False(rightStr_Any.IsLeft());
            Assert.False(rightInt_Any.IsLeft());

            Assert.True(Left("Error").IsLeft());
        }

        [Test]
        public void IsLeft_WhenLeftEitherContainValueAnConditionIsMet_RetrunsTrue()
        {
            Assert.True(leftStr_Any.IsLeft(x => x == str_Any));
            Assert.True(leftInt_10.IsLeft(x => x < 20));
            Assert.True(leftInt_Default.IsLeft(x => x == 0));
        }

        [Test]
        public void IsLeft_WhenLeftEitherContainNoValueAnConditionIsMet_RetrunsTrue()
        {
            Assert.False(leftStr_Any.IsLeft(x => x == "wrong string"));
            Assert.False(leftInt_10.IsLeft(x => x < 5));
            Assert.False(leftInt_Default.IsLeft(x => x != 0));
        }
    }
}
