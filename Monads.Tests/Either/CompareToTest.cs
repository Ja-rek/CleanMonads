using NUnit.Framework;
using static Monads.Either.EitherFactory;

namespace Monads.Tests.Either
{
    internal class CompareToTest : TestTemplate
    {
        [Test]
        public void CompareTo_WhenEitherHasTheSameValues_ReturnsZero()
        {
            Assert.True(rightStr_Any.CompareTo(rightStr_Any) == 0);
            Assert.True(rightStr_Default.CompareTo(rightStr_Default) == 0);
            Assert.True(rightStr_Any.CompareTo(Right(str_Any)) == 0);
            Assert.True(rightStr_Default.CompareTo(rightStr_Default) == 0);

            Assert.True(rightInt_Any.CompareTo(rightInt_Any) == 0);
            Assert.True(rightInt_Default.CompareTo(rightInt_Default) == 0);
            Assert.True(rightInt_Any.CompareTo(Right(int_Any)) == 0);
            Assert.True(rightInt_Default.CompareTo(Right(int_Default)) == 0);

            Assert.True(leftStr_Any.CompareTo(leftStr_Any) == 0);
            Assert.True(leftStr_Any.CompareTo(Left("something")) == 0);
            Assert.True(leftStr_Any.CompareTo(str_Any) == 0);

            Assert.True(leftInt_Any.CompareTo(leftInt_Any) == 0);
            Assert.True(leftInt_Any.CompareTo(Left(4564)) == 0);
            Assert.True(leftInt_Default.CompareTo(leftInt_Default) == 0);
            Assert.True(leftInt_Any.CompareTo(Left(int_Any)) == 0);
            Assert.True(leftInt_Default.CompareTo(Left(int_Any)) == 0);
        }

        [Test]
        public void CompareTo_WhenSourceIsGreater_ReturnsOne()
        {
            Assert.True(rightInt_20.CompareTo(int_10) ==  1);
            Assert.True(rightInt_20.CompareTo(rightInt_10) ==  1);
            Assert.True(rightStr_20.CompareTo(Right(str_10)) ==  1);
            Assert.True(rightStr_20.CompareTo(rightStr_10) ==  1);

            Assert.True(leftInt_20.CompareTo(Left(int_10)) ==  0);
            Assert.True(leftInt_20.CompareTo(leftInt_10) == 0);
            Assert.True(leftStr_20.CompareTo(Left(str_20)) == 0);
            Assert.True(leftStr_20.CompareTo(leftStr_10) == 0);
        }

        [Test]
        public void CompareTo_WhenSourceIsLesser_ReturnsMinusOne()
        {
            Assert.True(rightInt_10.CompareTo(int_20) == -1);
            Assert.True(rightInt_10.CompareTo(rightInt_20) == -1);
            Assert.True(rightStr_10.CompareTo(Right(str_20)) == -1);
            Assert.True(rightStr_10.CompareTo(rightStr_20) == -1);

            Assert.True(leftInt_10.CompareTo(Left(int_20)) == 0);
            Assert.True(leftInt_10.CompareTo(leftInt_20) == 0);
            Assert.True(leftStr_10.CompareTo(Left(str_20)) == 0);
            Assert.True(leftStr_10.CompareTo(leftStr_20) ==  0);
        }

        [Test]
        public void CompareTo_WhenSourceContaintRightEither_ReturnsMinusOne()
        {
            Assert.True(rightInt_Any.CompareTo(leftStr_Any) ==  1);
        }

        [Test]
        public void CompareTo_WhenSourceContaintLeftEither_ReturnsMinusOne()
        {
            Assert.True(leftStr_Any.CompareTo(rightInt_Any) ==  -1);
        }

    }
}
