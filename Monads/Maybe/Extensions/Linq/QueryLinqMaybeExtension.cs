using System;

namespace Monads.Extensions.Linq
{
    public static class QueryLinqMaybeExtension
    {
        public static Maybe<TData> Select<TSource, TData>(
            this Maybe<TSource> maybe, 
            Func<TSource, TData> selector)
        {
            return maybe.Map(selector);
        }

        public static Maybe<TData> SelectMany<TSource, TData>(
            this Maybe<TSource> maybe, 
            Func<TSource, Maybe<TData>> selector) 
        {
            return maybe.FlatMap(selector);
        }
        
        public static Maybe<TDataResult> SelectMany<TSource, TData, TDataResult>(
            this Maybe<TSource> maybe, 
            Func<TSource, Maybe<TData>> selector, 
            Func<TSource, TData, TDataResult> resultSelector)
        {
            return maybe.FlatMap(x => selector(x).Map(y => resultSelector(x, y)));
        }

        public static Maybe<TData> Where<TData>(
            this Maybe<TData> maybe, 
            Func<TData, bool> condition)
        {
            return maybe.Filter(condition);
        }
    }
}
