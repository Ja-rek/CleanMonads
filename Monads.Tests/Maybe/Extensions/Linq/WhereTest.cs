using NUnit.Framework;
using Monads.Maybe.Linq;

namespace Monads.Tests.Maybe.Extensions.Linq
{
    internal class WhereTest : TestTemplate
    {
        [Test]
        public void Where_WhenMaybeHasValue_ReturnsMaybeByCondtion()
        {
            var actual = maybeInt_10.Where(x => x == 10);

            Assert.AreEqual(maybeInt_10, actual);
        }

        [Test]
        public void Where_WhenMaybeHasNothing_ReturnsMaybeWitNothing()
        {
            var actual = int_Nothing.Where(x => x == 10);

            Assert.AreNotEqual(maybeInt_10, actual);
        }

        [Test]
        public void QueryWhere_WhenMaybeHasValue_ReturnsMaybeByCondtion()
        {
            var actual = from some in maybeInt_10
                         where some == 10
                         select some;

            Assert.AreEqual(maybeInt_10, actual);
        }

        [Test]
        public void QueryWhere_WhenMaybeHasNothing_ReturnsMaybeWithNothing()
        {
            var actual = from some in int_Nothing
                         where some == 10
                         select some;

            Assert.AreNotEqual(maybeInt_10, actual);
        }
    }
}
