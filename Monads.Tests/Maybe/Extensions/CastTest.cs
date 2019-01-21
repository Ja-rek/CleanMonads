using NUnit.Framework;
using Monads.Maybe;

namespace Monads.Tests.Maybe.Extensions
{
    internal class CastTest : TestTemplate
    {
        [Test]
        public void ToJustIf_WhenConditionIsMet_MaybeHasValue()
        {
            var maybeNumber10 = int_10.ToJustIf(x => x == int_10);

            Assert.True(maybeNumber10.HasValue());
        }

        [Test]
        public void ToJustIf_WhenConditionIsNotMet_MaybeHasNoValue()
        {
            var maybeAnyString = str_Any.ToJustIf(x => x == "bad value");

            Assert.False(maybeAnyString.HasValue());
        }

        [Test]
        public void ToNothingIf_WhenConditionIsMet_MaybeHasNoValue()
        {
            var maybeAnyString = str_Any.ToNothingIf(x => x == str_Any);

            Assert.False(maybeAnyString.HasValue());
        }

        [Test]
        public void ToNothingIf_WhenConditionIsNotMet_MaybeHasValue()
        {
            var maybeAnyString = str_Any.ToNothingIf(x => x == "bad value");

            Assert.True(maybeAnyString.HasValue());
        }

        [Test]
        public void ToMaybe_WhenSourceIsNullableAndContainValue_MaybeHasValue()
        {
            var maybeAnyString = nullableInt_10.ToMaybe();

            Assert.True(maybeAnyString.HasValue());
        }

        [Test]
        public void ToMaybe_WhenSourceIsNullableAndContainNoValue_MaybeHasNoValue()
        {
            var maybeAnyString = nullableInt_Null.ToMaybe();

            Assert.False(maybeAnyString.HasValue());
        }
    }
}
