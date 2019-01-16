using System;
using System.Collections.Generic;
using System.Linq;
using Monads.Common;
using static Monads.Maybe.MaybeFactory;

namespace Monads.Maybe.Enumerable
{
    public static class ElementAtOrNothingMaybeExtension
    {
        public static Maybe<TSource> ElementAtOrNothing<TSource>(this IEnumerable<TSource> source, int index)
        {
            Assert.ArgumentIsNotNull(source);

            var item = source.ElementAtOrDefault(index); 

            if (EqualityComparer<TSource>.Default.Equals(item, default)) 
            {
                return Nothing;
            }

            return Just(item);
        }
    }
}
