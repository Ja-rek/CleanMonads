using System;
using System.Collections.Generic;
using System.Linq;
using Monads.Common;

namespace Monads.Either.Enumerable
{
    public static class LastOrLeftEitherExtension
    {
        public static Either<TLeft, TRight> LastOrLeft<TLeft, TRight>(
            this IEnumerable<TRight> source, 
            TLeft left)
        {
            Assert.ArgumentIsNotNull(source);

            var item = source.LastOrDefault();

            return source.Any() ? (Either<TLeft, TRight>)item : left;
        }

        public static Either<TLeft, TRight> LastOrLeft<TLeft, TRight>(
            this IEnumerable<TRight> source, 
            Func<TRight, bool> condition,
            TLeft left)
        {
            Assert.ArgumentIsNotNull(source);

            if (source.Any(condition))
            {
                return source.First(condition);
            }

            return left;
        }

        public static Either<TLeft, TRight> LastOrLeft<TLeft, TRight>(
            this IEnumerable<TRight> source, 
            Func<TRight, bool> condition,
            Func<TLeft> leftFactory)
        {
            return source.LastOrLeft(condition, leftFactory());
        }

        public static Either<TLeft, TRight> LastOrLeft<TLeft, TRight>(
            this IEnumerable<TRight> source, 
            Func<TLeft> leftFactory)
        {
            return source.LastOrLeft(leftFactory());
        }
    }
}
