using System;
using static Monads.MaybeFactory;

namespace Monads.Utils.Parsers
{
    public static class GuidParser
    {
        public static Maybe<Guid> Parse(string source)
        {
            Guid parsed;
            if (Guid.TryParse(source, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Either<TLeft, Guid> Parse<TLeft>(string source, TLeft left)
        {
            Guid parsed;
            if (Guid.TryParse(source, out parsed))
            {
                return parsed;
            }

            return left;
        }
    }
}
