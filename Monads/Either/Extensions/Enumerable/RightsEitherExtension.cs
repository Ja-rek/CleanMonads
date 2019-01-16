using System.Collections.Generic;
using System.Linq;
using Monads.Common;

namespace Monads.Either.Enumerable
{
    public static class RightsEitherExtension
    {
        public static IEnumerable<TRight> Rights<TLeft, TRight>(
            this IEnumerable<Either<TLeft, TRight>> source)
        {
            Assert.ArgumentIsNotNull(source, nameof(source));

            return source.Where(x => x.IsRight()).Select(x => x.Right);
        }
    }
}
