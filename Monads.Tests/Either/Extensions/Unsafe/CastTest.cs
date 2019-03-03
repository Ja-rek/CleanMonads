using NUnit.Framework;
using System;
using Monads.Extensions.Unsafe;
using static Monads.EitherFactory;

namespace Monads.Tests.Either.Extensions.Unsafe
{
    internal class UnsafeTest : TestTemplate
    {
        [Test]
        public void RightOrFail_WhenRightEitherNotExist_ThrowException()
        {
            Assert.Throws<InvalidOperationException>(
                () => Left(str_Any).RightOrFail(str_Error));
        }
    }
}
