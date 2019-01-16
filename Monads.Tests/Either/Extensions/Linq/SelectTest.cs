using NUnit.Framework;
using Monads.Either.Linq;
using Monads.Either;
using System;

namespace Monads.Tests.Either.Extensions.Linq
{
    internal class SelectTest : TestTemplate
    {
        [Test]
        public void Select_WhenEitherContainValue_RetrunsSelectedValue()
        {
            var actual = rightInt_10.Select(x => x + 10);

            Assert.AreEqual(rightInt_20, actual);
        }

        [Test]
        public void Select_WhenEitherContainValue_RetrunsLeftEither()
        {
            var actual = leftStr_Error.Select(x => x + 10);

            Assert.AreEqual(leftStr_Error, actual);
        }

        [Test]
        public void QuerySelect_WhenEitherContainValue_RetrunsSelectedValue()
        {
            var actual = from just in rightInt_10
                         select just + 10;

            Assert.AreEqual(rightInt_20, actual);
        }

        [Test]
        public void QuerySelect_WhenEitherContainNone_ReturnsLeftEither()
        {
            var actual = from just in leftStr_Error
                         select just + 10;

            Assert.AreEqual(leftStr_Error, actual);
        }

        [Test]
        [TestCase(null)]
        public void Select_WhenArgumentIsNull_ThrowException(string arg)
        {
            Assert.Throws<ArgumentNullException>(() => 
                rightInt_Any.Select(x => arg));
        }
    }
}
