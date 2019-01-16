using NUnit.Framework;
using Monads.Maybe;
using static Monads.Maybe.MaybeFactory;
using System;

namespace Monads.Tests.Maybe.Extensions
{
    internal class MathcTest : TestTemplate
    {
        [Test]
        public void Match_WhenMaybeHasValue_RetrunsJust()
        {
            var expectedNumber10 = 10;

            var machedNumber = maybeInt_10.Match(
               just: val => val, 
               nothing: () => 5);

            Assert.AreEqual(expectedNumber10, machedNumber);
        }

        [Test]
        public void Match_WhenMaybeHasNoValue_ReturnsNothing()
        {
            var expectedNothing = "";

            var machedNumber = str_Nothing.Match(
               just: val => val, 
               nothing: () => expectedNothing);

            Assert.AreEqual(expectedNothing, machedNumber);
        }

        [Test]
        [TestCase(null, null)]
        [TestCase("any", null)]
        public void Match_WhenArgumentIsNull_ThrowException(string anyVal, string arg)
        {
            Assert.Throws<ArgumentNullException>(() => 
                MaybeFrom("any").Match(
                   just: val => arg, 
                   nothing: () => arg));
        }
    }
}
