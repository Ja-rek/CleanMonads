using NUnit.Framework;
using Monads.Maybe;

namespace Monads.Tests.Maybe.Extensions
{
    internal class OrTest : TestTemplate
    {
        [Test]
        public void Or_WhenMaybeHasValue_RetrunsDefaultMaybe()
        {

            var actual = maybeInt_10.Or(() => maybeInt_20);

            Assert.AreEqual(maybeInt_10, actual);
        }

        [Test]
        public void Or_WhenMaybeHasNothing_RetrunsAlternativeMaybe()
        {
            var actual = str_Nothing.Or(() => maybeStr_Any);

            Assert.AreEqual(maybeStr_Any, actual);
        }
    }
}
