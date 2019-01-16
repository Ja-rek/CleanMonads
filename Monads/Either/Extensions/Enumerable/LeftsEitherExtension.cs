using System.Collections.Generic;
using System.Linq;
using Monads.Common;

namespace Monads.Either.Enumerable
{
    public static class LeftsEitherExtension
    {
        public static IEnumerable<TLeft> Lefts<TLeft, TRight>(
            this IEnumerable<Either<TLeft, TRight>> source)
        {
            Assert.ArgumentIsNotNull(source, nameof(source));

            return source.Where(x => x.IsLeft()).Select(x => x.Left);
        }
    }
}
