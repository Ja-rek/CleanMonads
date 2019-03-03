using NUnit.Framework;
using static Monads.EitherFactory;

namespace Monads.Tests.Either
{
    internal class EqualsTest : TestTemplate
    {
        [Test]
        public void Equals_WhenBothAreTheSame_RetrunsTrue()
        {
            Assert.True(rightStr_Any.Equals(Right(str_Any)));

            Assert.True(rightStr_Any.Equals(rightStr_Any));
            Assert.True(leftStr_Error.Equals(leftStr_Error));
            Assert.True(leftStr_Error.Equals(Left("Error")));
            Assert.True(rightStr_Default.Equals(rightStr_Default));

            Assert.True(rightInt_Any.Equals(int_Any));
            Assert.True(rightInt_Any.Equals(rightInt_Any));
            Assert.True(rightInt_Default.Equals(rightInt_Default));

            Assert.True(Right(str_Any).Equals(rightStr_Any));
            Assert.True(Left("Error").Equals(leftStr_Error));
        }

        [Test]
        public void Equals_WhenFirstRightEitherIsGreater_RetrunsFalse()
        {
            Assert.False(rightInt_20.Equals(int_10));
            Assert.False(rightInt_20.Equals(rightInt_10));

            Assert.False(rightStr_20.Equals(Right(str_10)));
            Assert.False(rightStr_20.Equals(rightStr_10));
        }

        [Test]
        public void Equals_WhenFirstRightEitherIsLesser_RetrunsFalse()
        {
            Assert.False(rightInt_10.Equals(int_20));
            Assert.False(rightInt_10.Equals(rightInt_20));

            Assert.False(rightStr_10.Equals(Right(str_20)));
            Assert.False(rightStr_10.Equals(rightStr_20));
        }

        [Test]
        public void Equals_WhenFirstEitherIsLeft_RetrunsFalse()
        {
            Assert.False(Left("Error").Equals(rightInt_Any));
            Assert.False(Left("Error").Equals(int_Any));

            Assert.False(leftStr_Error.Equals(rightStr_Any));
            Assert.False(leftStr_Error.Equals(Right(str_Any)));
        }

        [Test]
        public void Equals_WhenFirstEitherIsRight_RetrunsFalse()
        {
            Assert.False(rightInt_Any.Equals("Error"));
            Assert.False(rightStr_Any.Equals(leftStr_Error));
            Assert.False(rightStr_Any.Equals(Left("Error")));
        }

        [Test]
        public void Equals_WhenFirstEitherIsDefault_RetrunsFalse()
        {
            Assert.False(rightInt_Default.Equals(rightInt_Any));
            Assert.False(rightInt_Default.Equals(int_Any));

            Assert.False(rightStr_Default.Equals(rightStr_Any));
            Assert.False(rightStr_Default.Equals(Right(str_Any)));
        }

        [Test]
        public void Equals_WhenSecondEitherIsDefault_RetrunsFalse()
        {
            Assert.False(rightInt_Any.Equals(rightInt_Default));
            Assert.False(rightStr_Any.Equals(rightStr_Default));
        }
    }
}
