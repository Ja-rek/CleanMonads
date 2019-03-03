using System;
using System.Globalization;
using static Monads.MaybeFactory;

namespace Monads.Utils.Parsers
{
    public static class DateTimeOffsetParser
    {
        public static Maybe<DateTimeOffset> Parse(string source)
        {
            DateTimeOffset parsed;

            if (DateTimeOffset.TryParse(source, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<DateTimeOffset> Parse(string source, IFormatProvider provider)
        {
            DateTimeOffset parsed;

            if (DateTimeOffset.TryParse(source, provider, DateTimeStyles.None, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<DateTimeOffset> Parse(string source, DateTimeStyles style)
        {
            DateTimeOffset parsed;

            if (DateTimeOffset.TryParse(source, CultureInfo.CurrentCulture, style, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<DateTimeOffset> Parse(string source, DateTimeStyles style, IFormatProvider provider)
        {
            DateTimeOffset parsed;

            if (DateTimeOffset.TryParse(source, provider, style, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<DateTimeOffset> ParseExact(string source, string format, DateTimeStyles style, IFormatProvider provider)
        {
            DateTimeOffset parsed;

            if (DateTimeOffset.TryParseExact(source, format, provider, style, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<DateTimeOffset> ParseExact(string source, string[] format, DateTimeStyles style, IFormatProvider provider)
        {
            DateTimeOffset parsed;

            if (DateTimeOffset.TryParseExact(source, format, provider, style, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }


        public static Either<TLeft, DateTimeOffset> Parse<TLeft>(string source, TLeft left)
        {
            DateTimeOffset parsed;

            if (DateTimeOffset.TryParse(source, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, DateTimeOffset> Parse<TLeft>(string source, IFormatProvider provider, TLeft left)
        {
            DateTimeOffset parsed;

            if (DateTimeOffset.TryParse(source, provider, DateTimeStyles.None, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, DateTimeOffset> Parse<TLeft>(string source, DateTimeStyles style, TLeft left)
        {
            DateTimeOffset parsed;

            if (DateTimeOffset.TryParse(source, CultureInfo.CurrentCulture, style, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, DateTimeOffset> Parse<TLeft>(
            string source, 
            DateTimeStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            DateTimeOffset parsed;

            if (DateTimeOffset.TryParse(source, provider, style, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, DateTimeOffset> ParseExact<TLeft>(
            string source, 
            string format, 
            DateTimeStyles style, 
            IFormatProvider provider,
            TLeft left)
        {
            DateTimeOffset parsed;

            if (DateTimeOffset.TryParseExact(source, format, provider, style, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, DateTimeOffset> ParseExact<TLeft>(
            string source, 
            string[] format, 
            DateTimeStyles style, 
            IFormatProvider provider,
            TLeft left)
        {
            DateTimeOffset parsed;

            if (DateTimeOffset.TryParseExact(source, format, provider, style, out parsed))
            {
                return parsed;
            }

            return left;
        }
    }
}
