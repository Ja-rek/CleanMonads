using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToBoolMaybeExtension
    {
        public static Maybe<bool> ParseToBool(this string source)
        {
            return BoolParser.Parse(source);
        }

        public static Maybe<bool> ParseToBool(this Maybe<string> source)
        {
            return source.FlatMap(BoolParser.Parse);
        }
    }
}
