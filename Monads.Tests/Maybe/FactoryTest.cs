using System;
using NUnit.Framework;
using static Monads.MaybeFactory;

namespace Monads.Tests.Maybe
{
    internal class FactoryTest : TestTemplate
    {
        [Test]
        public void Just_WhenFieldContainNull_ThrowsException()
        {
            string valStub = null;

            Assert.Throws<ArgumentNullException>(() => Just(valStub));
        }

        [Test]
        public void Just_WhenFieldHasValue_NotThrowsException()
        {
            string valStub = "val";

            Assert.AreEqual(valStub, Just(valStub).ValueOrEmpty());
        }
    }
}
