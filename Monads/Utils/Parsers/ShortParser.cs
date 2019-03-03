using System;
using System.Globalization;
using static Monads.MaybeFactory;

namespace Monads.Utils.Parsers
{
    public static class ShortParser
    {
        public static Maybe<short> Parse(string source)
        {
            short parsed;

            if (short.TryParse(source, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<short> Parse(string source, IFormatProvider provider)
        {
            short parsed;

            if (short.TryParse(source, NumberStyles.Any, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<short> Parse(string source, NumberStyles style)
        {
            short parsed;

            if (short.TryParse(source, style, CultureInfo.CurrentCulture, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<short> Parse(string source, NumberStyles style, IFormatProvider provider)
        {
            short parsed;

            if (short.TryParse(source, style, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Either<TLeft, short> Parse<TLeft>(string source, TLeft left)
        {
            short parsed;

            if (short.TryParse(source, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, short> Parse<TLeft>(string source, IFormatProvider provider, TLeft left)
        {
            short parsed;

            if (short.TryParse(source, NumberStyles.Any, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, short> Parse<TLeft>(string source, NumberStyles style, TLeft left)
        {
            short parsed;

            if (short.TryParse(source, style, CultureInfo.CurrentCulture, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, short> Parse<TLeft>(string source, NumberStyles style, IFormatProvider provider, TLeft left)
        {
            short parsed;

            if (short.TryParse(source, style, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }
    }
}
