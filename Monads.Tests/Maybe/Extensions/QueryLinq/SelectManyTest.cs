using NUnit.Framework;
using static Monads.MaybeFactory;
using Monads.Extensions.Linq;

namespace Monads.Tests.Maybe.Extensions.QueryLinq
{
    internal class SelectManyTest : TestTemplate
    {
        [Test]
        public void QuerySelectMany_WhenMaybeHasValue_RetrunsSelectedMaybe()
        {
            var actual = from justTwo in Just(Just(10))
                         from just in justTwo
                         select just;

            Assert.AreEqual(maybeInt_10, actual);
        }

        [Test]
        public void QuerySelectMany_WhenMaybeHasNothing_CanNotRetrunSelectedMaybe()
        {
            var actual = from justTwo in Just(MaybeFactory.MaybeOf<int>((int?)null))
                         from just in justTwo
                         select just;

            Assert.AreEqual(int_Nothing, actual);
        }
    }
}
