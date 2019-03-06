using System;
using System.Collections.Generic;
using System.Linq;

namespace Monads.Extensions.Linq
{
    public static class LinqEitherExtension
    {
        public static string AggregateLefts<TRight>(
            this IEnumerable<Either<string, TRight>> source)
        {
            Assert.ArgumentIsNotNull(source, nameof(source));

            return source
                .Where(x => x.IsLeft())
                .Select(x => x.ForceLeft)
                .Aggregate((x, y) => $"{x} {y}");
        }

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

        public static IEnumerable<TLeft> Lefts<TLeft, TRight>(
            this IEnumerable<Either<TLeft, TRight>> source)
        {
            Assert.ArgumentIsNotNull(source, nameof(source));

            return source.Where(x => x.IsLeft()).Select(x => x.ForceLeft);
        }

        public static IEnumerable<TRight> Rights<TLeft, TRight>(
            this IEnumerable<Either<TLeft, TRight>> source)
        {
            Assert.ArgumentIsNotNull(source, nameof(source));

            return source.Where(x => x.IsRight()).Select(x => x.ForceRight);
        }

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
