using NUnit.Framework;
using Monads.Either;
using System;
using System.Collections.Generic;
using NSubstitute;

namespace Monads.Tests.Either.Extensions
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

        [Test]
        [TestCase(null)]
        public void DoExtensionMethod_WhenSourceIsNull_ThrowException(Either<string, string> source)
        {
            var listStub = new List<string>();

            Assert.Throws<InvalidOperationException>(() => 
                source.Do(
                    left => listStub.Add(left),
                    right => listStub.Add(right)));
        }
    }
}
