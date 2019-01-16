using System;

namespace Monads.Either
{
    internal static class EitherAssert
    {
        public static void LeftOrRightExist<TLeft, TRight>(Either<TLeft, TRight> source)
        {
            if (!source.IsLeft() && !source.IsRight())
            {
                throw new InvalidOperationException("Left and right not exist.");
            }
        }

        public static void LeftExist<TLeft, TRight>(Either<TLeft, TRight> source)
        {
            if (!source.IsLeft())
            {
                throw new InvalidOperationException("Left not exist.");
            }
        }

        public static void RightExist<TLeft, TRight>(Either<TLeft, TRight> source)
        {
            if (!source.IsRight())
            {
                throw new InvalidOperationException("Right not exist.");
            }
        }
    }
}
