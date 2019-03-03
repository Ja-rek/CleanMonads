using NUnit.Framework;
using Monads.Extensions.Linq;

namespace Monads.Tests.Maybe.Extensions.QueryLinq
{
    internal class SelectTest : TestTemplate
    {
        [Test]
        public void QuerySelect_WhenMaybeHasValue_RetrunsSelectedMaybe()
        {
            var actual = from just in maybeInt_10
                         select just + 10;

            Assert.AreEqual(maybeInt_20, actual);
        }

        [Test]
        public void QuerySelect_WhenMaybeHasNothing_CanNotReturnSelectedMaybe()
        {
            var actual = from just in int_Nothing
                         select just + 10;

            Assert.AreNotEqual(maybeInt_10, actual);
        }
    }
}
