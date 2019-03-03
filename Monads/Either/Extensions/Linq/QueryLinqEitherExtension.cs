using System;

namespace Monads.Extensions.Linq
{
    public static class QueryLinqEitherExtension
    {
        public static Either<TLeft, TResult> Select<TLeft, TRight, TResult>(
            this Either<TLeft, TRight> source, 
            Func<TRight, TResult> selector)
        {
            return source.Map(selector);
        }

        public static Either<TLeft, TResult> SelectMany<TLeft, TRight, TResult>(
            this Either<TLeft, TRight> source, 
            Func<TRight, Either<TLeft, TResult>> selector)
        {
            return source.FlatMap(selector);
        }

        public static Either<TLeft, TResult> SelectMany<TLeft, TRight, TCollection, TResult>(
            this Either<TLeft, TRight> source, 
            Func<TRight, Either<TLeft, TCollection>> selector,
            Func<TRight, TCollection, TResult> resultSelector)
        {
            return source.FlatMap(x => selector(x).Map(y => resultSelector(x, y)));
        }
    }
}
