using System;
using static Monads.Either.EitherFactory;

namespace Monads.Either
{
    public static class CastEitherExtension
    {
        public static Either<TLeft, TRight> ToEither<TLeft, TRight>(this TRight right, TLeft left)
        {
            if (right != null) return new Either<TLeft, TRight>(right);
            if (left != null) return new Either<TLeft, TRight>(left);
                
            throw new InvalidOperationException("Both parameters cannot be null.");
        }

        public static Either<NotDefined, TRight> ToRight<TRight>(this TRight right)
        {
            return new Either<NotDefined, TRight>(right);
        }

        public static Either<TLeft, TRight> ToEither<TLeft, TRight>(this TRight right, Func<TLeft> left)
        {
            return right.ToEither(left());
        }

        public static Either<TLeft, NotDefined> ToLeft<TLeft>(this TLeft left)
        {
            return new Either<TLeft, NotDefined>(left);
        }

        public static Either<TLeft, TRight> ToRightIf<TLeft, TRight>(
            this TRight right, 
            Func<TRight, bool> condition, 
            TLeft left)
        {
            if (condition(right)) return Right(right);
                
            return Left(left);
        }

        public static Either<TLeft, TRight> ToRightIf<TLeft, TRight>(
            this TRight right, 
            Func<TRight, bool> condition, 
            Func<TLeft> left)
        {
            return right.ToRightIf(condition, left());
        }

        public static Either<TLeft, TRight> ToLeftIf<TLeft, TRight>(
            this TRight right, 
            Func<TRight, bool> condition, 
            TLeft left)
        {
            if (condition(right)) return Left(left);
                
            return Right(right);
        }

        public static Either<TLeft, TRight> ToLeftIf<TLeft, TRight>(
            this TRight right, 
            Func<TRight, bool> condition, 
            Func<TLeft> left)
        {
            return right.ToLeftIf(condition, left());
        }
    }
}
