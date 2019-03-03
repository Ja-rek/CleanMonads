using static Monads.MaybeFactory;

namespace Monads.Utils.Parsers
{
    public static class CharParser
    {
        public static Maybe<char> Parse(string source)
        {
            char parsed;

            if (char.TryParse(source, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Either<TLeft, char> Parse<TLeft>(string source, TLeft left)
        {
            char parsed;

            if (char.TryParse(source, out parsed))
            {
                return parsed;
            }

            return left;
        }
    }
}
