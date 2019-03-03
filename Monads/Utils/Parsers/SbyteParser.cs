using System;
using System.Globalization;
using static Monads.MaybeFactory;

namespace Monads.Utils.Parsers
{
    public static class SbyteParser
    {
        public static Maybe<sbyte> Parse(string source)
        {
            sbyte parsed;

            if (sbyte.TryParse(source, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<sbyte> Parse(string source, IFormatProvider provider)
        {
            sbyte parsed;

            if (sbyte.TryParse(source, NumberStyles.Any, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<sbyte> Parse(string source, NumberStyles style)
        {
            sbyte parsed;

            if (sbyte.TryParse(source, style, CultureInfo.CurrentCulture, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<sbyte> Parse(string source, NumberStyles style, IFormatProvider provider)
        {
            sbyte parsed;

            if (sbyte.TryParse(source, style, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Either<TLeft, sbyte> Parse<TLeft>(string source, TLeft left)
        {
            sbyte parsed;

            if (sbyte.TryParse(source, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, sbyte> Parse<TLeft>(string source, IFormatProvider provider, TLeft left)
        {
            sbyte parsed;

            if (sbyte.TryParse(source, NumberStyles.Any, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, sbyte> Parse<TLeft>(string source, NumberStyles style, TLeft left)
        {
            sbyte parsed;

            if (sbyte.TryParse(source, style, CultureInfo.CurrentCulture, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, sbyte> Parse<TLeft>(string source, NumberStyles style, IFormatProvider provider, TLeft left)
        {
            sbyte parsed;

            if (sbyte.TryParse(source, style, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }
    }
}
