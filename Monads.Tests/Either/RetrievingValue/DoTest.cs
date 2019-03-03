using NUnit.Framework;
using System.Collections.Generic;
using NSubstitute;

namespace Monads.Tests.Either.RetrievingValue
{
    internal class DoTest : TestTemplate
    {
        [Test]
        public void DoExtensionMethod_WhenRightEitherContainValue_RunRightSide()
        {
            var listMock = Substitute.For<IList<string>>();

            rightStr_10.Do(
                left => listMock.Add(left),
                right => listMock.Add(right));

            listMock.Received().Add("10");
        }

        [Test]
        public void DoExtensionMethod_WhenLeftEitherContainValue_RunLeftSide()
        {
            var listMock = Substitute.For<IList<int>>();

            leftInt_10.Do(
                left => listMock.Add(left),
                right => listMock.Add(right));

            listMock.Received().Add(10);
        }
    }
}
