using System;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToGuidEitherExtension
    {
        public static Either<TLeft, Guid> ParseToGuid<TLeft>(this string source, TLeft left)
        {
            return GuidParser.Parse(source, left);
        }

        public static Either<TLeft, Guid> ParseToGuid<TLeft>(this Either<TLeft, string> source, TLeft left)
        {
            return source.FlatMap(x => GuidParser.Parse(x, left));
        }
    }
}
