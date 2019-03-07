using System;

namespace Monads
{
    public static class ConversionEitherExtension
    {
        public static Either<TLeft, TRight> ToEither<TLeft, TRight>(this TRight right, TLeft left)
        {
            if (right != null) return right;

            return left;
        }

        public static Either<TLeft, TRight> ToEither<TLeft, TRight>(this TRight right, Func<TLeft> left)
        {
            return right.ToEither(left());
        }

        public static Either<TLeft, TRight> ToEither<TLeft, TRight>(this TRight? right, TLeft left) where TRight : struct
        {
            if (right.HasValue) return right.Value;
                
            return left;
        }

        public static Either<TLeft, TRight> ToEither<TLeft, TRight>(this TRight? right, Func<TLeft> left) where TRight : struct
        {
            return right.ToEither(left());
        }

        public static Either<NotDefined, TRight> ToRight<TRight>(this TRight right)
        {
            return right;
        }

        public static Either<TLeft, NotDefined> ToLeft<TLeft>(this TLeft left)
        {
            return left;
        }

        public static Either<TLeft, TRight> ToRightIf<TLeft, TRight>(
            this TRight right, 
            Func<TRight, bool> condition, 
            TLeft left)
        {
            if (condition(right)) return right;
                
            return left;
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
            if (condition(right)) return left;
                
            return right;
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
