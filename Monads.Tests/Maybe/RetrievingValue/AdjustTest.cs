using NUnit.Framework;
using System;

namespace Monads.Tests.Maybe.RetrievingValue
{
    internal class AdjustTest : TestTemplate
    {
        [Test]
        public void Adjust_WhenFieldHasValue_RetrunsJust()
        {
            var expectedNumber10 = 10;

            var machedNumber = maybeInt_10.Adjust(
               just: val => val, 
               nothing: () => 5);

            Assert.AreEqual(expectedNumber10, machedNumber);
        }

        [Test]
        public void Adjust_WhenFieldHasNoValue_ReturnsNothing()
        {
            var expectedNothing = "";

            var machedNumber = str_Nothing.Adjust(
               just: val => val, 
               nothing: () => expectedNothing);

            Assert.AreEqual(expectedNothing, machedNumber);
        }

        [Test]
        [TestCase(null, null)]
        [TestCase("any", null)]
        public void Adjust_WhenArgumentIsNull_ThrowException(string anyVal, string arg)
        {
            Assert.Throws<ArgumentNullException>(() =>
                MaybeFactory.MaybeOf("any").Adjust(
                   just: val => arg, 
                   nothing: () => arg));
        }
    }
}
