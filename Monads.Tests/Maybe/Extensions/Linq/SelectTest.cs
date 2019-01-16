using NUnit.Framework;
using Monads.Maybe.Linq;
using System;

namespace Monads.Tests.Maybe.Extensions.Linq
{
    internal class SelectTest : TestTemplate
    {
        [Test]
        public void Select_WhenMaybeHasValue_RetrunsSelectedMaybe()
        {
            var actual = maybeInt_10.Select(x => x + 10);

            Assert.AreEqual(maybeInt_20, actual);
        }

        [Test]
        public void Select_WhenMaybeHasNothing_CanNotReturnSelectedMaybe()
        {
            var actual = int_Nothing.Select(x => x + 10);

            Assert.AreNotEqual(maybeInt_10, actual);
        }

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

        [Test]
        public void Select_WhenArgumentIsNull_ThrowException()
        {
            string factory = null;
            Assert.Throws<ArgumentNullException>(() => 
                maybeStr_Any.Select(x => factory));
        }
    }
}
