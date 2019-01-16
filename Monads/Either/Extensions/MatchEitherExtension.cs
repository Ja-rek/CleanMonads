using System;
using Monads.Common;

namespace Monads.Either
{
    public static class MatchEitherExtension
    {
        public static TRight Match<TLeft, TRight>(
            this Either<TLeft, TRight> source, 
            Func<TLeft, TRight> left,
            Func<TRight, TRight> right)
        {
            EitherAssert.LeftOrRightExist(source);

            if (source.IsRight()) 
            {
                var rightArg = right(source.Right);

                Assert.ArgumentIsNotNull(rightArg, nameof(right));

                return rightArg;
            }

            var leftArg = left(source.Left);

            Assert.ArgumentIsNotNull(leftArg, nameof(left));

            return left(source.Left);
        }
   }
}
