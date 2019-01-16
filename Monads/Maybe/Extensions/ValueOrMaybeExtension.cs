using System;
using Monads.Common;

namespace Monads.Maybe
{
    public static class ValueOrMaybeExtension
    {
        public static TData ValueOr<TData>(this Maybe<TData> source, TData alternative)
        { 
            Assert.ArgumentIsNotNull(alternative);

            return !source.HasValue() ? (TData)alternative : source.Value;
        }

        public static TData ValueOr<TData>(this Maybe<TData> source, Func<TData> alternativeFactory)
        {
            return source.ValueOr(alternativeFactory());
        }
    }
}
