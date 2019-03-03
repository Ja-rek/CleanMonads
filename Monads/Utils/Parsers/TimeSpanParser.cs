using System;
using System.Globalization;
using static Monads.MaybeFactory;

namespace Monads.Utils.Parsers
{
    public static class TimeSpanParser
    {
        public static Maybe<TimeSpan> Parse(string source)
        {
            TimeSpan parsed;
            if (TimeSpan.TryParse(source, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<TimeSpan> Parse(string source, IFormatProvider provider)
        {
            TimeSpan parsed;
            if (TimeSpan.TryParse(source, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<TimeSpan> ParseExact(string source, string format, TimeSpanStyles style, IFormatProvider provider)
        {
            TimeSpan parsed;
            if (TimeSpan.TryParseExact(source, format, provider, style, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<TimeSpan> ParseExact(string source, string[] format, TimeSpanStyles style, IFormatProvider provider)
        {
            TimeSpan parsed;
            if (TimeSpan.TryParseExact(source, format, provider, style, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<TimeSpan> ParseExact(string source, string[] format, IFormatProvider provider)
        {
            TimeSpan parsed;
            if (TimeSpan.TryParseExact(source, format, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<TimeSpan> ParseExact(string source, string format, IFormatProvider provider)
        {
            TimeSpan parsed;
            if (TimeSpan.TryParseExact(source, format, provider, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Either<TLeft, TimeSpan> Parse<TLeft>(string source, TLeft left)
        {
            TimeSpan parsed;
            if (TimeSpan.TryParse(source, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, TimeSpan> Parse<TLeft>(string source, IFormatProvider provider, TLeft left)
        {
            TimeSpan parsed;
            if (TimeSpan.TryParse(source, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, TimeSpan> ParseExact<TLeft>(string source, string format, TimeSpanStyles style, IFormatProvider provider, TLeft left)
        {
            TimeSpan parsed;
            if (TimeSpan.TryParseExact(source, format, provider, style, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, TimeSpan> ParseExact<TLeft>(string source, string[] format, TimeSpanStyles style, IFormatProvider provider, TLeft left)
        {
            TimeSpan parsed;
            if (TimeSpan.TryParseExact(source, format, provider, style, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, TimeSpan> ParseExact<TLeft>(string source, string[] format, IFormatProvider provider, TLeft left)
        {
            TimeSpan parsed;
            if (TimeSpan.TryParseExact(source, format, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, TimeSpan> ParseExact<TLeft>(string source, string format, IFormatProvider provider, TLeft left)
        {
            TimeSpan parsed;
            if (TimeSpan.TryParseExact(source, format, provider, out parsed))
            {
                return parsed;
            }

            return left;
        }
    }
}
