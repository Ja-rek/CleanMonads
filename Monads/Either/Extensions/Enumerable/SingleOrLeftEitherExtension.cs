using System;
using System.Collections.Generic;
using System.Linq;
using Monads.Common;

namespace Monads.Either.Enumerable
{
    public static class SingleOrLeftEitherExtension
    {
        public static Either<TLeft, TRight> SingleOrLeft<TLeft, TRight>(this IEnumerable<TRight> source, TLeft left)
        {
            Assert.ArgumentIsNotNull(source);

            if (source.Count() == 1) return source.Single();

            return left;
        }

        public static Either<TLeft, TRight> SingleOrLeft<TLeft, TRight>(
            this IEnumerable<TRight> source, 
            Func<TRight, bool> condition,
            TLeft left)
        {
            Assert.ArgumentIsNotNull(source);

            return source
                .Where(condition)
                .SingleOrLeft(left);
        }

        public static Either<TLeft, TRight> SingleOrLeft<TLeft, TRight>(
            this IEnumerable<TRight> source, 
            Func<TRight, bool> condition,
            Func<TLeft> leftFactory)
        {
            return source.SingleOrLeft(condition, leftFactory());
        }

        public static Either<TLeft, TRight> SingleOrLeft<TLeft, TRight>(
            this IEnumerable<TRight> source, 
            Func<TLeft> leftFactory)
        {
            return source.SingleOrLeft(leftFactory());
        }
    }
}
