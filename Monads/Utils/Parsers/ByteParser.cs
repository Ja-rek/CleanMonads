using System;
using System.Globalization;
using static Monads.MaybeFactory;

namespace Monads.Utils.Parsers
{
    public static class ByteParser
    {
        public static Maybe<byte> Parse(string source)
        {
            byte parsed;

            if (byte.TryParse(source, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<byte> Parse(string source, IFormatProvider provider)
        {
            byte parsed;

            if (byte.TryParse(source, NumberStyles.Any, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<byte> Parse(string source, NumberStyles style)
        {
            byte parsed;

            if (byte.TryParse(source, style, CultureInfo.CurrentCulture, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<byte> Parse(string source, NumberStyles style, IFormatProvider provider)
        {
            byte parsed;

            if (byte.TryParse(source, style, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Either<TLeft, byte> Parse<TLeft>(string source, TLeft left)
        {
            byte parsed;

            if (byte.TryParse(source, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, byte> Parse<TLeft>(string source, IFormatProvider provider, TLeft left)
        {
            byte parsed;

            if (byte.TryParse(source, NumberStyles.Any, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, byte> Parse<TLeft>(string source, NumberStyles style, TLeft left)
        {
            byte parsed;

            if (byte.TryParse(source, style, CultureInfo.CurrentCulture, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, byte> Parse<TLeft>(string source, NumberStyles style, IFormatProvider provider, TLeft left)
        {
            byte parsed;

            if (byte.TryParse(source, style, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }
    }
}
