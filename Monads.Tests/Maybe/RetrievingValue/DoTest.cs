using NUnit.Framework;
using NSubstitute;
using System.Collections.Generic;

namespace Monads.Tests.Maybe.RetrievingValue
{
    internal class DoTest : TestTemplate
    {
        [Test]
        public void Do_WhenFieldHasValue_DoJust()
        {
            var listMock = Substitute.For<IList<int>>();

            maybeInt_10.Do(
               just: x => listMock.Add(x), 
               nothing: () => listMock.Add(0));

            listMock.Received().Add(10);
        }

        [Test]
        public void Do_WhenFieldHasNoValue_DoNothing()
        {
            var listMock = Substitute.For<IList<int>>();

            int_Nothing.Do(
               just: x => listMock.Add(x), 
               nothing: () => listMock.Add(0));

            listMock.Received().Add(0);
        }
    }
}
