using NUnit.Framework;
using System;
using Monads.Either.Unsafe;
using static Monads.Either.EitherFactory;

namespace Monads.Tests.Either.Extensions
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
