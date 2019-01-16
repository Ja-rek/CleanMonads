using System;
using Monads.Common;

namespace Monads.Either
{
    public static class EitherFactory
    {
        public static Either<TLeft, NotDefined> Left<TLeft>(TLeft left)
        {
            return left.ToLeft();
        }

        public static Either<NotDefined, TRight> Right<TRight>(TRight right)
        {
            return right.ToRight();
        }

        public static Either<TLeft, TRight> EitherFrom<TRight, TLeft>(TLeft left, TRight right)
        {
            return right.ToEither(left);
        }
    }
}
