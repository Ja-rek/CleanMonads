using static Monads.MaybeFactory;

namespace Monads.Utils.Parsers
{
    public static class BoolParser
    {
        public static Maybe<bool> Parse(string source)
        {
            bool parsed;

            if (bool.TryParse(source, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Either<TLeft, bool> Parse<TLeft>(string source, TLeft left)
        {
            bool parsed;

            if (bool.TryParse(source, out parsed))
            {
                return parsed;
            }

            return left;
        }
    }
}
