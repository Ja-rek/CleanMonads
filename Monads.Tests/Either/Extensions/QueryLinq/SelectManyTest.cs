using NUnit.Framework;
using static Monads.EitherFactory;
using Monads.Extensions.Linq;

namespace Monads.Tests.Either.Extensions.QueryLinq
{
    internal class SelectManyTest : TestTemplate
    {
        [Test]
        public void QuerySelectMany_WhenEitherContainValue_RetrunsSelectedValue()
        {
            var flattenRight = from justTwo in Right(Right(str_Any))
                               from just in justTwo
                               select just;

            Assert.AreEqual(rightStr_Any, flattenRight);
        }
    }
}
