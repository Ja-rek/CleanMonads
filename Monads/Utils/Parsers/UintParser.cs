using System;
using System.Globalization;
using static Monads.MaybeFactory;

namespace Monads.Utils.Parsers
{
    public static class UintParser
    {
        public static Maybe<uint> Parse(string source)
        {
            uint parsed;

            if (uint.TryParse(source, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<uint> Parse(string source, IFormatProvider provider)
        {
            uint parsed;

            if (uint.TryParse(source, NumberStyles.Any, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<uint> Parse(string source, NumberStyles style)
        {
            uint parsed;

            if (uint.TryParse(source, style, CultureInfo.CurrentCulture, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<uint> Parse(string source, NumberStyles style, IFormatProvider provider)
        {
            uint parsed;

            if (uint.TryParse(source, style, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Either<TLeft, uint> Parse<TLeft>(string source, TLeft left)
        {
            uint parsed;

            if (uint.TryParse(source, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, uint> Parse<TLeft>(string source, IFormatProvider provider, TLeft left)
        {
            uint parsed;

            if (uint.TryParse(source, NumberStyles.Any, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, uint> Parse<TLeft>(string source, NumberStyles style, TLeft left)
        {
            uint parsed;

            if (uint.TryParse(source, style, CultureInfo.CurrentCulture, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, uint> Parse<TLeft>(string source, NumberStyles style, IFormatProvider provider, TLeft left)
        {
            uint parsed;

            if (uint.TryParse(source, style, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }
    }
}
