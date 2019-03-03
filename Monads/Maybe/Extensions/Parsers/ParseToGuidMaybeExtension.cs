using System;
using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToGuidMaybeExtension
    {
        public static Maybe<Guid> ParseToGuid(this string source)
        {
            return GuidParser.Parse(source);
        }

        public static Maybe<Guid> ParseToGuid(this Maybe<string> source)
        {
            return source.FlatMap(GuidParser.Parse);
        }
    }
}
