using System;
using System.Globalization;
using static Monads.MaybeFactory;

namespace Monads.Utils.Parsers
{
    public static class LongParser
    {
        public static Maybe<long> Parse(string source)
        {
            long parsed;

            if (long.TryParse(source, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<long> Parse(string source, IFormatProvider provider)
        {
            long parsed;

            if (long.TryParse(source, NumberStyles.Any, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<long> Parse(string source, NumberStyles style)
        {
            long parsed;

            if (long.TryParse(source, style, CultureInfo.CurrentCulture, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<long> Parse(string source, NumberStyles style, IFormatProvider provider)
        {
            long parsed;

            if (long.TryParse(source, style, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Either<TLeft, long> Parse<TLeft>(string source, TLeft left)
        {
            long parsed;

            if (long.TryParse(source, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, long> Parse<TLeft>(string source, IFormatProvider provider, TLeft left)
        {
            long parsed;

            if (long.TryParse(source, NumberStyles.Any, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, long> Parse<TLeft>(string source, NumberStyles style, TLeft left)
        {
            long parsed;

            if (long.TryParse(source, style, CultureInfo.CurrentCulture, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, long> Parse<TLeft>(string source, NumberStyles style, IFormatProvider provider, TLeft left)
        {
            long parsed;

            if (long.TryParse(source, style, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }
    }
}
