using System;
using System.Collections.Generic;
using System.Linq;
using Monads.Common;
using static Monads.Maybe.MaybeFactory;

namespace Monads.Maybe.Enumerable
{
    public static class LastOrNothingMaybeExtension
    {
        public static Maybe<TSource> LastOrNothing<TSource>(this IEnumerable<TSource> source)
        {
            Assert.ArgumentIsNotNull(source);

            return source.Any() ? MaybeFrom(source.Last()) : Nothing;
        }

        public static Maybe<TSource> LastOrNothing<TSource>(
            this IEnumerable<TSource> source, 
            Func<TSource, bool> condition)
        {
            Assert.ArgumentIsNotNull(source);

            return source.Any(condition) ? MaybeFrom(source.Last(condition)) : Nothing;
        }
    }
}
