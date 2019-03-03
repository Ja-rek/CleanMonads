using System;
using System.Globalization;
using static Monads.MaybeFactory;

namespace Monads.Utils.Parsers
{
    public static class DoubleParser
    {
        public static Maybe<double> Parse(string source)
        {
            double parsed;

            if (double.TryParse(source, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<double> Parse(string source, IFormatProvider provider)
        {
            double parsed;

            if (double.TryParse(source, NumberStyles.Any, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<double> Parse(string source, NumberStyles style)
        {
            double parsed;

            if (double.TryParse(source, style, CultureInfo.CurrentCulture, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<double> Parse(string source, NumberStyles style, IFormatProvider provider)
        {
            double parsed;

            if (double.TryParse(source, style, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Either<TLeft, double> Parse<TLeft>(string source, TLeft left)
        {
            double parsed;

            if (double.TryParse(source, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, double> Parse<TLeft>(string source, IFormatProvider provider, TLeft left)
        {
            double parsed;

            if (double.TryParse(source, NumberStyles.Any, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, double> Parse<TLeft>(string source, NumberStyles style, TLeft left)
        {
            double parsed;

            if (double.TryParse(source, style, CultureInfo.CurrentCulture, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, double> Parse<TLeft>(string source, NumberStyles style, IFormatProvider provider, TLeft left)
        {
            double parsed;

            if (double.TryParse(source, style, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }
    }
}
