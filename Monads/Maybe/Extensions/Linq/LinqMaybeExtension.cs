using System;
using System.Collections.Generic;
using System.Linq;
using static Monads.MaybeFactory;

namespace Monads.Extensions.Linq
{
    public static class LnqMaybeExtension
    {
        public static Maybe<TSource> ElementAtOrNothing<TSource>(this IEnumerable<TSource> source, int index)
        {
            Assert.ArgumentIsNotNull(source);

            var item = source.ElementAtOrDefault(index); 

            if (EqualityComparer<TSource>.Default.Equals(item, default)) 
            {
                return Nothing;
            }

            return item;
        }

        public static IEnumerable<TSource> Values<TSource>(this IEnumerable<Maybe<TSource>> source)
        {
            Assert.ArgumentIsNotNull(source);

            return source
                .Where(x => x.HasValue())
                .Select(x => x.ForceValue);
        }

        public static Maybe<TSource> FirstOrNothing<TSource>(this IEnumerable<TSource> source)
        {
            Assert.ArgumentIsNotNull(source);

            return source.Any() ? MaybeOf(source.First()) : Nothing;
        }

        public static Maybe<TSource> FirstOrNothing<TSource>(
            this IEnumerable<TSource> source, 
            Func<TSource, bool> condition)
        {
            Assert.ArgumentIsNotNull(source);

            return source.Any(condition) ? MaybeOf(source.First(condition)) : Nothing;
        }

        public static Maybe<TSource> LastOrNothing<TSource>(this IEnumerable<TSource> source)
        {
            Assert.ArgumentIsNotNull(source);

            return source.Any() ? MaybeOf(source.Last()) : Nothing;
        }

        public static Maybe<TSource> LastOrNothing<TSource>(
            this IEnumerable<TSource> source, 
            Func<TSource, bool> condition)
        {
            Assert.ArgumentIsNotNull(source);

            return source.Any(condition) ? MaybeOf(source.Last(condition)) : Nothing;
        }

        public static Maybe<TSource> SingleOrNothing<TSource>(this IEnumerable<TSource> source)
        {
            Assert.ArgumentIsNotNull(source);

            return source.Count() == 1 ? MaybeOf(source.Single()) : Nothing;
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
