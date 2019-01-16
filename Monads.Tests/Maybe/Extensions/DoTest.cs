using NUnit.Framework;
using NSubstitute;
using System.Collections.Generic;
using Monads.Maybe;

namespace Monads.Tests.Maybe.Extensions
{
    internal class DoTest : TestTemplate
    {
        [Test]
        public void Do_WhenMaybeHasValue_DoJust()
        {
            var listMock = Substitute.For<IList<int>>();

            maybeInt_10.Do(
               just: x => listMock.Add(x), 
               nothing: () => listMock.Add(0));

            listMock.Received().Add(10);
        }

        [Test]
        public void Do_WhenMaybeHasNoValue_DoNothing()
        {
            var listMock = Substitute.For<IList<int>>();

            int_Nothing.Do(
               just: x => listMock.Add(x), 
               nothing: () => listMock.Add(0));

            listMock.Received().Add(0);
        }
    }
}