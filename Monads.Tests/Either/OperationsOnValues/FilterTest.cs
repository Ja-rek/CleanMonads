using System;
using NUnit.Framework;

namespace Monads.Tests.Either.OperationsOnValues
{
    internal class FilterTest : TestTemplate
    {
        [Test]
        public void Filter_WhenEitherContainRightValueAndConditionIsMet_RetrunsRightEither()
        {
            var actual = rightInt_10.Filter(x => x == 10, str_Error);

            Assert.AreEqual(rightInt_10, actual);
        }

        [Test]
        public void Filter_WhenEitherContainRightValueAndConditionIsNotMet_RetrunsLeftEither()
        {
            var actual = rightInt_10.Filter(x => x != 10, str_Any);

            Assert.AreEqual(leftStr_Any, actual);
        }

        [Test]
        public void Filter_WhenEitherContainLeftValue_DoNotExecuteCondition()
        {
            leftInt_10.Filter(x => throw new Exception(), int_10);
        }

        [Test]
        public void Filter_WhenEitherContainLeftValueAndConditionCanNotBeMet_RetrunsLeftEither()
        {
            var actual = leftStr_Error.Filter(x => x == 10, str_Error);

            Assert.AreEqual(leftStr_Error, actual);
        }
    }
}
