using NUnit.Framework;
using System;

namespace Monads.Tests.Either.ValueOperations
{
    internal class MapTest : TestTemplate
    {
        [Test]
        public void Map_WhenEitherContainValue_RetrunsMapedValue()
        {
            var actual = rightInt_10.Map(x => x + 10);

            Assert.AreEqual(rightInt_20, actual);
        }

        [Test]
        public void Map_EitherContainNoValue_DoNotThrowsException()
        {
            var actual = leftStr_Error
                .Map(x => x / 0);

            Assert.AreEqual(actual, leftStr_Error);
        }

        [Test]
        public void Map_WhenEitherContainValue_RetrunsLeftEither()
        {
            var actual = leftStr_Error.Map(x => x + 10);

            Assert.AreEqual(leftStr_Error, actual);
        }
        [Test]
        [TestCase(null)]
        public void Map_WhenArgumentIsNull_ThrowException(string arg)
        {
            Assert.Throws<ArgumentNullException>(() => 
                rightInt_Any.Map(x => arg));
        }
    }
}
