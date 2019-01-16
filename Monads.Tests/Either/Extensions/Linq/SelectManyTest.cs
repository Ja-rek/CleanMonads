using NUnit.Framework;
using static Monads.Either.EitherFactory;
using Monads.Either.Linq;
using Monads.Either;
using System;

namespace Monads.Tests.Either.Extensions.Linq
{
    internal class SelectManyTest : TestTemplate
    {
        [Test]
        public void SelectMany_WhenEitherContainValue_RetrunsSelectedValue()
        {
            var flattenRight = Right(Right(str_Any))
                .SelectMany(x => x);

            Assert.AreEqual(rightStr_Any, flattenRight);
        }

        [Test]
        public void SelectMany_WhenEitherContainValue_RetrunsLeftEither()
        {
            var inner = EitherFrom(str_Error, (string)null);
            var either = EitherFrom(str_Error, inner);

            var actual = either.SelectMany(x => x).RightOrLeft();

            Assert.AreEqual(str_Error, actual);
        }

        [Test]
        public void QuerySelectMany_WhenEitherContainValue_RetrunsSelectedValue()
        {
            var flattenRight = from justTwo in Right(Right(str_Any))
                               from just in justTwo
                               select just;

            Assert.AreEqual(rightStr_Any, flattenRight);
        }

        [Test]
        public void QuerySelectMany_WhenEitherContainNone_ReturnsLeftEither()
        {
            var inner = EitherFrom(str_Error,(string)null);
            var either = EitherFrom(str_Error, inner);

            var selected = from justTwo in either
                           from just in justTwo
                           select just;

            var actual = selected.RightOrLeft();

            Assert.AreEqual(str_Error, actual);
        }

        [Test]
        [TestCase(null)]
        public void SelectMany_WhenArgumentIsNull_ThrowException(Either<string, string> arg)
        {
            Assert.Throws<InvalidOperationException>(() => 
                rightStr_Any.SelectMany(x => arg));
        }
    }
}
