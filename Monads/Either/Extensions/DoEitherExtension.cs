using System;

namespace Monads.Either
{
    public static class DoEitherExtension
    {
        public static void Do<TLeft, TRight>(
            this Either<TLeft, TRight> source, 
            Action<TLeft> left,
            Action<TRight> right)
        {
            source.DoWhenIsLeft(left);
            source.DoWhenIsRight(right);
        }

        public static void DoWhenIsRight<TLeft, TRight>(
            this Either<TLeft, TRight> source, 
            Action<TRight> right)
        {
            EitherAssert.LeftOrRightExist(source);

            if (source.IsRight()) right(source.Right);
        }

        public static void DoWhenIsLeft<TLeft, TRight>(
            this Either<TLeft, TRight> source, 
            Action<TLeft> left)
        {
            EitherAssert.LeftOrRightExist(source);

            if (source.IsLeft()) left(source.Left);
        }
   }
}
