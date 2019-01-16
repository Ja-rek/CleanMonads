using NUnit.Framework;
using Monads.Either.Enumerable;
using System;
using System.Collections.Generic;
using Monads.Either;

namespace Monads.Tests.Either.Extensions.Linq
{
    internal class AggregateLeftsTest : TestTemplate
    {
        [Test]
        public void AggregateLefts_WhenListHasRightDataAndLeft_ReturnsAgregatedLefts()
        {
            var list = new List<Either<string, int>> { str_Error, 5, str_Error };

            var actual = list.AggregateLefts();
            var expected = $"{str_Error} {str_Error}";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void AggregateLefts_WhenListIsNull_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => listOfEihtersIsNull.AggregateLefts());       
        }

    }
}
