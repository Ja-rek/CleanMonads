using System;
using System.Collections.Generic;
using System.Linq;
using Monads.Common;
using static Monads.Maybe.MaybeFactory;

namespace Monads.Maybe.Enumerable
{
    public static class FirstOrNothingMaybeExtension
    {
        public static Maybe<TSource> FirstOrNothing<TSource>(this IEnumerable<TSource> source)
        {
            Assert.ArgumentIsNotNull(source);

            return source.Any() ? MaybeFrom(source.First()) : Nothing;
        }

        public static Maybe<TSource> FirstOrNothing<TSource>(
            this IEnumerable<TSource> source, 
            Func<TSource, bool> condition)
        {
            Assert.ArgumentIsNotNull(source);

            return source.Any(condition) ? MaybeFrom(source.First(condition)) : Nothing;
        }
    }
}
