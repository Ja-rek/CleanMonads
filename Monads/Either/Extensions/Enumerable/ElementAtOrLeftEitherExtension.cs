using System;
using System.Collections.Generic;
using System.Linq;
using Monads.Common;

namespace Monads.Either.Enumerable
{
    public static class ElementAtOrLeftEitherExtension
    {
        public static Either<TLeft, TRight> ElementAtOrLeft<TLeft, TRight>(
            this IEnumerable<TRight> source,
            int index,
            TLeft left)
        {
            Assert.ArgumentIsNotNull(source, nameof(source));

            var item = source.ElementAtOrDefault(index);

            if (EqualityComparer<TRight>.Default.Equals(item, default))
            {
                return left;
            }
                
            return  item;
        }

        public static Either<TLeft, TRight> ElementAtOrLeft<TLeft, TRight>(
            this IEnumerable<TRight> source,
            int index,
            Func<TLeft> leftFactory)
        {
            return source.ElementAtOrLeft(index, leftFactory());
        }
    }
}
