using System.Collections.Generic;
using System.Linq;
using Monads.Common;

namespace Monads.Either.Enumerable
{
    public static class AgregateLeftsEitherExtension
    {
        public static string AggregateLefts<TRight>(
            this IEnumerable<Either<string, TRight>> source)
        {
            Assert.ArgumentIsNotNull(source, nameof(source));

            return source
                .Where(x => x.IsLeft())
                .Select(x => x.Left)
                .Aggregate((x, y) => $"{x} {y}");
        }
    }
}
