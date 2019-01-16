using System;
using System.Collections.Generic;
using System.Linq;
using Monads.Common;

namespace Monads.Either.Enumerable
{
    public static class FirstOrLeftEitherExtension
    {
        public static Either<TLeft, TRight> FirstOrLeft<TLeft, TRight>(this IEnumerable<TRight> source, TLeft left)
        {
            Assert.ArgumentIsNotNull(source);

            if (source.Any()) return source.First();

            return left; 
        }

        public static Either<TLeft, TRight> FirstOrLeft<TLeft, TRight>(
            this IEnumerable<TRight> source, 
            Func<TRight, bool> condition,
            TLeft left)
        {
            Assert.ArgumentIsNotNull(source);

            if (source.Any(condition)) return source.First(condition);

            return left; 
        }

        public static Either<TLeft, TRight> FirstOrLeft<TLeft, TRight>(
            this IEnumerable<TRight> source, 
            Func<TLeft> leftFactory)
        {
            return source.FirstOrLeft(leftFactory());
        }

        public static Either<TLeft, TRight> FirstOrLeft<TLeft, TRight>(
            this IEnumerable<TRight> source, 
            Func<TRight, bool> condition,
            Func<TLeft> leftFactory)
        {
            return source.FirstOrLeft(condition, leftFactory());
        }
    }
}
