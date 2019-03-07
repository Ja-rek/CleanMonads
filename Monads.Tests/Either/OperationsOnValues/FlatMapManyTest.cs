using NUnit.Framework;
using static Monads.EitherFactory;

namespace Monads.Tests.Either.OperationsOnValues
{
    internal class FlatMapTest : TestTemplate
    {
        [Test]
        public void FlatMap_WhenEitherContainValue_RetrunsSelectedValue()
        {
            var flattenRight = Right(Right(str_Any))
                .FlatMap(x => x);

            Assert.AreEqual(rightStr_Any, flattenRight);
        }

        [Test]
        public void FlatMap_EitherContainNoValue_DoNotThrowsException()
        {
            var actual = leftStr_Error
                .FlatMap(x => (x / 0).ToEither("any"));

            Assert.AreEqual(actual, leftStr_Error);
        }
    }
}
