using NUnit.Framework;

namespace Monads.Tests.Maybe.ValueOperations
{
    internal class MapTest : TestTemplate
    {
        [Test]
        public void Map_WhenMaybeHasValue_RetrunsMapedMaybe()
        {
            var actual = maybeInt_10.Map(x => x + 10);

            Assert.AreEqual(maybeInt_20, actual);
        }

        [Test]
        public void Map_WhenMaybeHasNoValueAndTryResoveMethodThatThrowExceptionWhenArgumentIsNull_ThenDoNotThrowsException()
        {
            var actual = str_Nothing
                .Map(x => x.Replace("any", string.Empty));

            Assert.AreEqual(actual, str_Nothing);
        }

        [Test]
        public void Map_WhenMaybeHasNothing_CanNotReturnMapedMaybe()
        {
            var actual = int_Nothing.Map(x => x + 10);

            Assert.AreNotEqual(maybeInt_10, actual);
        }
    }
}
