using System;

namespace Monads.Maybe
{
    public static class OrMaybeExtension
    {
        public static Maybe<TData> Or<TData>(this Maybe<TData> source, Maybe<TData> alternative)
        { 
            return !source.HasValue() ? alternative : source;
        }

        public static Maybe<TData> Or<TData>(this Maybe<TData> source, Func<Maybe<TData>> alternativeFactory)
        {
            return source.Or(alternativeFactory());
        }
    }
}
