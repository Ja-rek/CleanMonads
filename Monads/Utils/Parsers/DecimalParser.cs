using System;
using System.Globalization;
using static Monads.MaybeFactory;

namespace Monads.Utils.Parsers
{
    public static class DecimalParser
    {
        public static Maybe<decimal> Parse(string source)
        {
            decimal parsed;

            if (decimal.TryParse(source, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<decimal> Parse(string source, IFormatProvider provider)
        {
            decimal parsed;

            if (decimal.TryParse(source, NumberStyles.Any, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<decimal> Parse(string source, NumberStyles style)
        {
            decimal parsed;

            if (decimal.TryParse(source, style, CultureInfo.CurrentCulture, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<decimal> Parse(string source, NumberStyles style, IFormatProvider provider)
        {
            decimal parsed;

            if (decimal.TryParse(source, style, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Either<TLeft, decimal> Parse<TLeft>(string source, TLeft left)
        {
            decimal parsed;

            if (decimal.TryParse(source, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, decimal> Parse<TLeft>(string source, IFormatProvider provider, TLeft left)
        {
            decimal parsed;

            if (decimal.TryParse(source, NumberStyles.Any, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, decimal> Parse<TLeft>(string source, NumberStyles style, TLeft left)
        {
            decimal parsed;

            if (decimal.TryParse(source, style, CultureInfo.CurrentCulture, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, decimal> Parse<TLeft>(string source, NumberStyles style, IFormatProvider provider, TLeft left)
        {
            decimal parsed;

            if (decimal.TryParse(source, style, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }
    }
}
