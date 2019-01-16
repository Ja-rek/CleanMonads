using NUnit.Framework;
using static Monads.Maybe.MaybeFactory;
using Monads.Maybe.Linq;
using System;

namespace Monads.Tests.Maybe.Extensions.Linq
{
    internal class SelectManyTest : TestTemplate
    {
        [Test]
        public void Select_WhenMaybeHasValue_RetrunsSelectedMaybe()
        {
            var actual = Just(Just(10))
                .SelectMany(x => x);

            Assert.AreEqual(maybeInt_10, actual);
        }

        [Test]
        public void Select_WhenMaybeHasNothing_CanNotReturnSelectedMaybe()
        {
            var actual = Just(MaybeFrom((int?)null))
                .SelectMany(x => x);

            Assert.AreEqual(int_Nothing, actual);
        }

        [Test]
        public void QuerySelect_WhenMaybeHasValue_RetrunsSelectedMaybe()
        {
            var actual = from justTwo in Just(Just(10))
                         from just in justTwo
                         select just;

            Assert.AreEqual(maybeInt_10, actual);
        }

        [Test]
        public void QuerySelect_WhenMaybeHasNothing_CanNotRetrunSelectedMaybe()
        {
            var actual = from justTwo in Just(MaybeFrom((int?)null))
                         from just in justTwo
                         select just;

            Assert.AreEqual(int_Nothing, actual);
        }

        [Test]
        public void SelectMany_WhenArgumentIsNull_ThrowException()
        {
            string factory = null;
            Assert.Throws<ArgumentNullException>(() => 
                maybeStr_Any.Select(x => factory));
        }
    }
}
