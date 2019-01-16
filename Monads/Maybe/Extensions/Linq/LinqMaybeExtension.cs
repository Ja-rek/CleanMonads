using System;
using Monads.Common;
using Monads.Maybe.Unsafe;
using static Monads.Maybe.MaybeFactory;

namespace Monads.Maybe.Linq
{
    public static class LinqMaybeExtension
    {
        public static Maybe<TData> Select<TSource, TData>(
            this Maybe<TSource> maybe, 
            Func<TSource, TData> selector)
        {
            Assert.ArgumentIsNotNull(selector(maybe.ValueOrDefault()));

            return maybe.Bind(selector);
        }

        public static Maybe<TData> SelectMany<TSource, TData>(
            this Maybe<TSource> maybe, 
            Func<TSource, Maybe<TData>> selector) 
        {
            Assert.ArgumentIsNotNull(selector(maybe.ValueOrDefault()));

            return maybe.Bind(selector);
        }

        public static Maybe<TDataResult> SelectMany<TSource, TData, TDataResult>(
            this Maybe<TSource> maybe, 
            Func<TSource, Maybe<TData>> selector, 
            Func<TSource, TData, TDataResult> resultSelector)
        {
            Assert.ArgumentIsNotNull(selector(maybe.ValueOrDefault()));

            return maybe.Bind(x => selector(x).Bind(y => resultSelector(x, y)));
        }

        public static Maybe<TData> Where<TData>(
            this Maybe<TData> maybe, 
            Func<TData, bool> condition)
        {
            return maybe.HasValue() | condition(maybe.Value)
                ? maybe.Value
                : (Maybe<TData>)MaybeFactory.Nothing;
        }

    }
}
