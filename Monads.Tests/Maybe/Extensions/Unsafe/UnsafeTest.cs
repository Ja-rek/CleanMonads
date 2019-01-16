using NUnit.Framework;
using System;
using Monads.Maybe.Unsafe;

namespace Monads.Tests.Maybe.Extensions
{
    internal class UnsafeTest : TestTemplate
    {
        [Test]
        public void ValueOrFail_WhenArgumentIsNull_ThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => maybeStr_Default.Value());
        }

        [Test]
        public void ValueOrDefault_WhenArgumentIsNull_ThrowException()
        {
            var message = "Test";

            Assert.Throws<InvalidOperationException>(
                () => maybeStr_Default.ValueOrFail(message),
                message);
        }
    }
}
