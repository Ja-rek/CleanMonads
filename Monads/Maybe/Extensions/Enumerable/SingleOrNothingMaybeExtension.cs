using System;
using System.Collections.Generic;
using System.Linq;
using Monads.Common;
using static Monads.Maybe.MaybeFactory;

namespace Monads.Maybe.Enumerable
{
    public static class SingleOrNothingMaybeExtension
    {
        public static Maybe<TSource> SingleOrNothing<TSource>(this IEnumerable<TSource> source)
        {
            Assert.ArgumentIsNotNull(source);

            return source.Count() == 1 ? MaybeFrom(source.Single()) : Nothing;
        }

        public static Maybe<TSource> SingleOrNothing<TSource>(
            this IEnumerable<TSource> source, 
            Func<TSource, bool> condition)
        {
            Assert.ArgumentIsNotNull(source);

            return source.Where(condition).SingleOrNothing();
        }
    }
}
