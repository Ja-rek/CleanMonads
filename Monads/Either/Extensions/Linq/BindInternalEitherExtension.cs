using System;
using Monads.Common;
using static Monads.Either.EitherFactory;

namespace Monads.Either.Linq
{
    internal static class BindInternalEitherExtension
    {
        public static Either<TLeft, TResult> Bind<TLeft, TRight, TResult>(
            this Either<TLeft, TRight> source,
            Func<TRight, TResult> predicate)
        {
            EitherAssert.LeftOrRightExist(source);

            if (source.IsRight())
            {
                var predicateArg = predicate(source.Right);

                Assert.ArgumentIsNotNull(predicateArg, nameof(predicateArg));

                return Right(predicateArg);
            }

            return Left(source.Left);
        }

        public static Either<TLeft, TResult> Bind<TLeft, TRight, TResult>(
            this Either<TLeft, TRight> source,
            Func<TRight, Either<TLeft, TResult>> predicate)
        {
            EitherAssert.LeftOrRightExist(source);

            var predicateArg = predicate(source.Right);

            EitherAssert.LeftOrRightExist(predicateArg);

            return source.IsRight() ? predicateArg : Left(source.Left);
        }
    }
}
