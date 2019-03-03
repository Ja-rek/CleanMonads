using System;
using System.Globalization;
using static Monads.MaybeFactory;

namespace Monads.Utils.Parsers
{
    public static class UshortParser
    {
        public static Maybe<ushort> Parse(string source)
        {
            ushort parsed;

            if (ushort.TryParse(source, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<ushort> Parse(string source, IFormatProvider provider)
        {
            ushort parsed;

            if (ushort.TryParse(source, NumberStyles.Any, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<ushort> Parse(string source, NumberStyles style)
        {
            ushort parsed;

            if (ushort.TryParse(source, style, CultureInfo.CurrentCulture, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<ushort> Parse(string source, NumberStyles style, IFormatProvider provider)
        {
            ushort parsed;

            if (ushort.TryParse(source, style, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Either<TLeft, ushort> Parse<TLeft>(string source, TLeft left)
        {
            ushort parsed;

            if (ushort.TryParse(source, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, ushort> Parse<TLeft>(string source, IFormatProvider provider, TLeft left)
        {
            ushort parsed;

            if (ushort.TryParse(source, NumberStyles.Any, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, ushort> Parse<TLeft>(string source, NumberStyles style, TLeft left)
        {
            ushort parsed;

            if (ushort.TryParse(source, style, CultureInfo.CurrentCulture, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, ushort> Parse<TLeft>(string source, NumberStyles style, IFormatProvider provider, TLeft left)
        {
            ushort parsed;

            if (ushort.TryParse(source, style, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }
    }
}
