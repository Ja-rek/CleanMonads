using NUnit.Framework;
using Monads.Either.Enumerable;
using System;
using System.Linq;

namespace Monads.Tests.Either.Extensions.Linq
{
    internal class LeftsTest : TestTemplate
    {
        [Test]
        public void Lefts_WhenListHasRightDataAndLeft_ReturnsRights()
        {
            var actual = listOf_Right1_LeftError.Lefts();

            Assert.AreEqual(str_Error, actual.First());
            Assert.True(actual.Count() == 1);
        }

        [Test]
        public void Lefts_WhenListIsNull_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => listOfEihtersIsNull.Lefts());       
        }

    }
}
