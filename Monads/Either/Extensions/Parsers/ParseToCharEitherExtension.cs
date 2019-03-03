using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToCharEitherExtension
    {
        public static Either<TLeft, char> ParseToChar<TLeft>(this string source, TLeft left)
        {
            return CharParser.Parse(source, left);
        }

        public static Either<TLeft, char> ParseToChar<TLeft>(this Either<TLeft, string> source, TLeft left)
        {
            return source.FlatMap(x => CharParser.Parse(x, left));
        }
    }
}
