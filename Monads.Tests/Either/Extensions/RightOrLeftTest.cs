using NUnit.Framework;
using Monads.Either;
using System;

namespace Monads.Tests.Either.Extensions
{
    internal class RightOrLeftLeftTest : TestTemplate
    {
        [Test]
        public void RightOrLeft_WhenRightEitherContainValue_RetrunsRightValue()
        {
            var actual = rightStr_10.RightOrLeft();

            Assert.AreEqual(str_10, actual);
        }

        [Test]
        public void RightOrLeft_WhenLeftEitherContainValue_RetrunsLeftValue()
        {
            var actual = leftInt_10.RightOrLeft();

            Assert.AreEqual(int_10, actual);
        }

        [Test]
        [TestCase(null)]
        public void RightOrLeft_WhenSourceIsNull_ThrowException(Either<int, int> source)
        {
            Assert.Throws<InvalidOperationException>(() => source.RightOrLeft());
        }
    }
}
