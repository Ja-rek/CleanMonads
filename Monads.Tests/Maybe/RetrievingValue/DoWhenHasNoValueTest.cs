using NUnit.Framework;
using NSubstitute;
using System.Collections.Generic;

namespace Monads.Tests.Maybe.RetrievingValue
{
    internal class DoWhenHasNoValueTest : TestTemplate
    {
        [Test]
        public void DoWhenHasNoValue_WhenMaybeHasNoValue_RunsMethod()
        {
            var listMock = Substitute.For<IList<int>>();

            int_Nothing.DoWhenHasNoValue(
                () => listMock.Add(0));

            listMock.Received().Add(0);
        }

        [Test]
        public void DoWhenHasNoValue_WhenMaybeHasValue_NotRunsMethod()
        {
            var listMock = Substitute.For<IList<int>>();

            maybeInt_Any.DoWhenHasNoValue(
                () => listMock.Add(0));

            listMock.DidNotReceive().Add(0);;
        }
    }
}
