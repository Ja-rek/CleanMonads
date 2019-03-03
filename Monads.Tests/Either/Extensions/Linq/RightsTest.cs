using NUnit.Framework;
using Monads.Extensions.Linq;
using System;
using System.Linq;

namespace Monads.Tests.Either.Extensions.Linq
{
    internal class RightsTest : TestTemplate
    {
        [Test]
        public void Rights_WhenListHasRightDataAndLeft_ReturnsRights()
        {
            var actual = listOf_Right1_LeftError.Rights();

            Assert.AreEqual(1, actual.First());
            Assert.True(actual.Count() == 1);
        }

        [Test]
        public void Rights_WhenListIsNull_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => listOfEihtersIsNull.Rights());       
        }

    }
}
