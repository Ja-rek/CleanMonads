using System;
using Monads.Common;

namespace Monads.Either
{
    public static class RightOrEitherExtension
    {
        public static TRight RightOr<TLeft, TRight>(
            this Either<TLeft, TRight> source, 
            Func<TLeft, TRight>  left)
        { 
            EitherAssert.LeftOrRightExist(source);

            if (source.IsRight()) return source.Right;

            var leftArg = left(source.Left);

            Assert.ArgumentIsNotNull(leftArg);

            return leftArg;
        }
    }
}
