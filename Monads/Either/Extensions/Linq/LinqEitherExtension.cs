using System;
using Monads.Common;
using static Monads.Either.EitherFactory;

namespace Monads.Either.Linq
{
    public static class LinqEitherExtension
    {
        public static Either<TLeft, TResult> Select<TLeft, TRight, TResult>(
            this Either<TLeft, TRight> source, 
            Func<TRight, TResult> selector)
        {
            Assert.ArgumentIsNotNull(selector(source.Right));

            return source.Bind(selector);
        }

        public static Either<TLeft, TResult> SelectMany<TLeft, TRight, TResult>(
            this Either<TLeft, TRight> source, 
            Func<TRight, Either<TLeft, TResult>> selector)
        {
            Assert.ArgumentIsNotNull(selector(source.Right));

            return source.Bind(selector);
        }

        public static Either<TLeft, TResult> SelectMany<TLeft, TRight, TCollection, TResult>(
            this Either<TLeft, TRight> source, 
            Func<TRight, Either<TLeft, TCollection>> selector,
            Func<TRight, TCollection, TResult> resultSelector)
        {
            Assert.ArgumentIsNotNull(selector(source.Right));

            return source.Bind(x => selector(x).Bind(y => resultSelector(x, y)));
        }

        public static Either<TLeft, TRight> Where<TLeft, TRight>(
            this Either<TLeft, TRight> source, 
            Func<TRight, bool> condition,
            TLeft left)
        {
            Assert.ArgumentIsNotNull(left, nameof(left));

            if (source.IsRight() && condition(source.Right)) 
            {
                Console.WriteLine(source.Right);
                return Right(source.Right);
            }
                
            return Left(left);
        }

        public static Either<TLeft, TRight> Where<TLeft, TRight>(
            this Either<TLeft, TRight> source, 
            Func<TRight, bool> condition,
            Func<TLeft> left)
        {
            return source.Where(condition, left());
        }
    }
}
