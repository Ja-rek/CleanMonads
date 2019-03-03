using NUnit.Framework;
using static Monads.MaybeFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using Monads.Extensions.Linq;

namespace Monads.Tests.Maybe.Extensions.Linq
{
    internal class ValuesTest : TestTemplate
    {
        [Test]
        public void Values_WhenListHasJustsDataAndNothing_ReturnsOnlyValues()
        {
            var listOfMaybesWithNothing = new List<Maybe<string>> { Nothing, Just(str_Any), Nothing };
            
            var justValuesOfList = listOfMaybesWithNothing.Values();
            var expectedItem = str_Any;

            Assert.AreEqual(expectedItem, justValuesOfList.First());
            Assert.True(justValuesOfList.Count() == 1);
        }
        
        [Test]
        public void Values_WhenListIsEmpty_ReturnsEmptyList()
        {
            var emptyList = new List<Maybe<string>>();
            
            var justValuesOfList = emptyList.Values();

            Assert.False(justValuesOfList.Any());
        }

        [Test]
        public void Values_WhenListIsNull_ThrowException()
        {
            List<Maybe<int>> listOfMaybesStub = null;

            Assert.Throws<ArgumentNullException>(() => listOfMaybesStub.Values());       
        }

    }
}
