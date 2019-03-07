using System;

namespace Monads
{
    public static class EitherFactory
    {
        public static Either<TLeft, NotDefined> Left<TLeft>(TLeft left)
        {
            return left;
        }

        public static Either<TLeft, TRight> Left<TLeft, TRight>(TLeft left)
        {
            return left;
        }

        public static Either<NotDefined, TRight> Right<TRight>(TRight right)
        {
            return right;
        }

        public static Either<TLeft, TRight> Right<TLeft, TRight>(TRight right)
        {
            return right;
        }

        public static Either<TLeft, TRight> EitherOf<TRight, TLeft>(TLeft left, TRight right)
        {
            return right.ToEither(left);
        }

        public static Either<TLeft, TRight> EitherOf<TRight, TLeft>(TLeft left, TRight? right) where TRight : struct
        {
            return right.Value.ToEither(left);
        }

        public static Either<TLeft, TRight> EitherOf<TRight, TLeft>(TLeft left, Func<TRight?> right) where TRight : struct
        {
            return right().Value.ToEither(left);
        }

        public static Either<TLeft, TRight> EitherOf<TRight, TLeft>(TLeft left, Func<TRight> right)
        {
            return right().ToEither(left);
        }
    }
}
