using NUnit.Framework;
using NSubstitute;
using System.Collections.Generic;

namespace Monads.Tests.Maybe.RetrievingValue
{
    internal class DoWhenHasValueTest : TestTemplate
    {
        [Test]
        public void DoWhenHasValue_WhenMaybeHasValue_RunMethod()
        {
            var listMock = Substitute.For<IList<int>>();

            maybeInt_10.DoWhenHasValue(
                just => listMock.Add(just));

            listMock.Received().Add(10);
        }

        [Test]
        public void DoWhenHasValue_WhenMaybeHasNoValue_NotRunMethod()
        {
            var listMock = Substitute.For<IList<int>>();

            int_Nothing.DoWhenHasValue(
                just => listMock.Add(0));

            listMock.DidNotReceive().Add(0);;
        }
    }
}
