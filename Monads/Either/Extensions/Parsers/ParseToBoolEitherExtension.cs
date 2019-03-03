using Monads.Utils.Parsers;

namespace Monads.Extensions.Parsers
{
    public static class ParseToBoolEitherExtension
    {
        public static Either<TLeft ,bool> ParseToBool<TLeft>(this string source, TLeft left)
        {
            return BoolParser.Parse(source, left);
        }

        public static Either<TLeft ,bool> ParseToBool<TLeft>(this Either<TLeft, string> source, TLeft left)
        {
            return source.FlatMap(x => BoolParser.Parse(x, left));
        }
    }
}
