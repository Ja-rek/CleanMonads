using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToCharMaybeExtension
    {
        public static Maybe<char> ParseToChar(this string source)
        {
            return CharParser.Parse(source);
        }

        public static Maybe<char> ToMayBechar(this Maybe<string> source)
        {
            return source.FlatMap(CharParser.Parse);
        }
    }
}
