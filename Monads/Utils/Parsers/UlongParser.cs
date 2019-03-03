using System;
using System.Globalization;
using static Monads.MaybeFactory;

namespace Monads.Utils.Parsers
{
    public static class UlongParser
    {
        public static Maybe<ulong> Parse(string source)
        {
            ulong parsed;

            if (ulong.TryParse(source, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<ulong> Parse(string source, IFormatProvider provider)
        {
            ulong parsed;

            if (ulong.TryParse(source, NumberStyles.Any, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<ulong> Parse(string source, NumberStyles style)
        {
            ulong parsed;

            if (ulong.TryParse(source, style, CultureInfo.CurrentCulture, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<ulong> Parse(string source, NumberStyles style, IFormatProvider provider)
        {
            ulong parsed;

            if (ulong.TryParse(source, style, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Either<TLeft, ulong> Parse<TLeft>(string source, TLeft left)
        {
            ulong parsed;

            if (ulong.TryParse(source, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, ulong> Parse<TLeft>(string source, IFormatProvider provider, TLeft left)
        {
            ulong parsed;

            if (ulong.TryParse(source, NumberStyles.Any, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, ulong> Parse<TLeft>(string source, NumberStyles style, TLeft left)
        {
            ulong parsed;

            if (ulong.TryParse(source, style, CultureInfo.CurrentCulture, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, ulong> Parse<TLeft>(string source, NumberStyles style, IFormatProvider provider, TLeft left)
        {
            ulong parsed;

            if (ulong.TryParse(source, style, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }
    }
}
