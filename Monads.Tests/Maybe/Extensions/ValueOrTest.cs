using NUnit.Framework;
using Monads.Maybe;
using System;

namespace Monads.Tests.Maybe.Extensions
{
    internal class ValueOrTest : TestTemplate
    {
        [Test]
        public void ValueOr_WhenMaybeHasValue_RetrunsValueFromMonad()
        {
            var actual = maybeInt_10.ValueOr(() => 20);

            Assert.AreEqual(10, actual);
        }

        [Test]
        public void ValueOr_WhenMaybeHasNothing_RetrunsAlternativeValue()
        {
            var actual = str_Nothing.ValueOr(() => str_Any);

            Assert.AreEqual(str_Any, actual);
        }

        [Test]
        public void ValueOr_WhenArgumentIsNull_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => maybeStr_Any.ValueOr(() => (string)null));
        }
    }
}
