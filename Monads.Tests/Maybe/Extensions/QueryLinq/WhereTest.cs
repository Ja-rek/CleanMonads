using NUnit.Framework;
using Monads.Extensions.Linq;

namespace Monads.Tests.Maybe.Extensions.Query
{
    internal class WhereTest : TestTemplate
    {
        [Test]
        public void QueryWhere_WhenFieldHasValue_ReturnsMaybeByCondtion()
        {
            var actual = from some in maybeInt_10
                         where some == 10
                         select some;

            Assert.AreEqual(maybeInt_10, actual);
        }

        [Test]
        public void QueryWhere_WhenFieldHasNothing_ReturnsMaybeWithNothing()
        {
            var actual = from some in int_Nothing
                         where some == 10
                         select some;

            Assert.AreNotEqual(maybeInt_10, actual);
        }
    }
}
