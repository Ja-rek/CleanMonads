using NUnit.Framework;
using static Monads.MaybeFactory;

namespace Monads.Tests.Maybe.ValueOperations
{
    internal class FlatMapTest : TestTemplate
    {
        [Test]
        public void FlatMap_WhenFieldHasValue_RetrunsSelectedMaybe()
        {
            var actual = Just(Just(10))
                .FlatMap(x => x);

            Assert.AreEqual(maybeInt_10, actual);
        }

        [Test]
        public void FlatMap_WhenFieldHasNoValueAndTryResoveMethodThatThrowExceptionWhenArgumentIsNull_ThenDoNotThrowsException()
        {
            var actual = str_Nothing
                .FlatMap(x => x.Replace("any", string.Empty).ToMaybe());

            Assert.AreEqual(actual, str_Nothing);
        }

        [Test]
        public void FlatMap_WhenFieldHasNothing_CanNotReturnSelectedMaybe()
        {
            var actual = Just(MaybeOf((int?)null))
                .FlatMap(x => x);

            Assert.AreEqual(int_Nothing, actual);
        }
    }
}
