using NUnit.Framework;

namespace Monads.Tests.Maybe.RetrievingValue
{
    internal class OrTest : TestTemplate
    {
        [Test]
        public void Or_WhenFieldHasValue_RetrunsDefaultMaybe()
        {

            var actual = maybeInt_10.Or(() => maybeInt_20);

            Assert.AreEqual(maybeInt_10, actual);
        }

        [Test]
        public void Or_WhenFieldHasNothing_RetrunsAlternativeMaybe()
        {
            var actual = str_Nothing.Or(() => maybeStr_Any);

            Assert.AreEqual(maybeStr_Any, actual);
        }
    }
}
