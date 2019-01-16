using System;
using System.Collections.Generic;
using System.Linq;
using Monads.Common;

namespace Monads.Maybe.Enumerable
{
    public static class ExtraMaybeExtension
    {
        public static Maybe<TSource> FirstOr<TSource>(this IEnumerable<TSource> source, TSource alternative)
        {
            Assert.ArgumentIsNotNull(source);
            Assert.ArgumentIsNotNull(alternative);

            return source.Any() ? source.First() : alternative;
        }

        public static Maybe<TSource> FirstOr<TSource>(
            this IEnumerable<TSource> source, 
            TSource alternative, 
            Func<TSource, bool> condition)
        {
            Assert.ArgumentIsNotNull(source);
            Assert.ArgumentIsNotNull(alternative);

            return source.Any() ? source.First(condition) : alternative;
        }

        public static IEnumerable<TSource> Values<TSource>(this IEnumerable<Maybe<TSource>> source)
        {
            Assert.ArgumentIsNotNull(source);

            return source.Where(x => x.HasValue()).Select(x => x.Value);
        }
    }
}
