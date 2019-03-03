using System;
using System.Globalization;
using static Monads.MaybeFactory;

namespace Monads.Utils.Parsers
{
    public static class IntParser
    {
        public static Maybe<int> Parse(string source)
        {
            int parsed;

            if (int.TryParse(source, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<int> Parse(string source, IFormatProvider provider)
        {
            int parsed;

            if (int.TryParse(source, NumberStyles.Any, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<int> Parse(string source, NumberStyles style)
        {
            int parsed;

            if (int.TryParse(source, style, CultureInfo.CurrentCulture, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<int> Parse(string source, NumberStyles style, IFormatProvider provider)
        {
            int parsed;

            if (int.TryParse(source, style, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Either<TLeft, int> Parse<TLeft>(string source, TLeft left)
        {
            int parsed;

            if (int.TryParse(source, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, int> Parse<TLeft>(string source, IFormatProvider provider, TLeft left)
        {
            int parsed;

            if (int.TryParse(source, NumberStyles.Any, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, int> Parse<TLeft>(string source, NumberStyles style, TLeft left)
        {
            int parsed;

            if (int.TryParse(source, style, CultureInfo.CurrentCulture, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, int> Parse<TLeft>(string source, NumberStyles style, IFormatProvider provider, TLeft left)
        {
            int parsed;

            if (int.TryParse(source, style, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }
    }
}
