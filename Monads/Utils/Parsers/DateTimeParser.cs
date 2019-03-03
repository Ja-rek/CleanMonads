using System;
using System.Globalization;
using static Monads.MaybeFactory;

namespace Monads.Utils.Parsers
{
    public static class DateTimeParser
    {
        public static Maybe<DateTime> Parse(string source)
        {
            DateTime parsed;

            if (DateTime.TryParse(source, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<DateTime> Parse(string source, IFormatProvider provider)
        {
            DateTime parsed;

            if (DateTime.TryParse(source, provider, DateTimeStyles.None, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<DateTime> Parse(string source, DateTimeStyles style)
        {
            DateTime parsed;

            if (DateTime.TryParse(source, CultureInfo.CurrentCulture, style, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<DateTime> Parse(string source, DateTimeStyles style, IFormatProvider provider)
        {
            DateTime parsed;

            if (DateTime.TryParse(source, provider, style, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<DateTime> ParseExact(string source, string format, DateTimeStyles style, IFormatProvider provider)
        {
            DateTime parsed;

            if (DateTime.TryParseExact(source, format, provider, style, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }

        public static Maybe<DateTime> ParseExact(string source, string[] format, DateTimeStyles style, IFormatProvider provider)
        {
            DateTime parsed;

            if (DateTime.TryParseExact(source, format, provider, style, out parsed))
            {
                return parsed;
            }

            return Nothing;
        }


        public static Either<TLeft, DateTime> Parse<TLeft>(string source, TLeft left)
        {
            DateTime parsed;

            if (DateTime.TryParse(source, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, DateTime> Parse<TLeft>(string source, IFormatProvider provider, TLeft left)
        {
            DateTime parsed;

            if (DateTime.TryParse(source, provider, DateTimeStyles.None, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, DateTime> Parse<TLeft>(string source, DateTimeStyles style, TLeft left)
        {
            DateTime parsed;

            if (DateTime.TryParse(source, CultureInfo.CurrentCulture, style, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, DateTime> Parse<TLeft>(
            string source, 
            DateTimeStyles style, 
            IFormatProvider provider, 
            TLeft left)
        {
            DateTime parsed;

            if (DateTime.TryParse(source, provider, style, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, DateTime> ParseExact<TLeft>(
            string source, 
            string format, 
            DateTimeStyles style, 
            IFormatProvider provider,
            TLeft left)
        {
            DateTime parsed;

            if (DateTime.TryParseExact(source, format, provider, style, out parsed))
            {
                return parsed;
            }

            return left;
        }

        public static Either<TLeft, DateTime> ParseExact<TLeft>(
            string source, 
            string[] format, 
            DateTimeStyles style, 
            IFormatProvider provider,
            TLeft left)
        {
            DateTime parsed;

            if (DateTime.TryParseExact(source, format, provider, style, out parsed))
            {
                return parsed;
            }

            return left;
        }
    }
}
